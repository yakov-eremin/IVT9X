<?php
class URL{
	private $pages_path;//путь до папки со страницами (по умолчанию корень сайта)
	private $main_page = NULL;//имя файла главной страницы
	private $page_404 = NULL;//имя файла ошибки 404
	private $pages;//древовидный массив со страницами
	private $url;//сейчасный url
	private $id_list;//массив использованных id
	private $current_page = '';//сейчасная страница(название файла)
	private $current_id = '';//сейчасная страница(ID)
	private $current_parametres = '';//параметры сейчасной страницы
	
	function __construct(){
		//$pages_path = $_SERVER['DOCUMENT_ROOT'].'/pages/';
		$this->pages_path = $_SERVER['DOCUMENT_ROOT'].'/';
		$this->url = urldecode(parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH));
		$this->pages = array();
		$this->id_list = array();
	}
	
	/*
	* добавление страницы
	* 
	* $id - уникальный ID, используется для привязки детей
	* $url_slice - кусочек УРЛа
	* $file_name - имя файла страницы (нулл для узла без страницы)
	* $parent_id - ID родителя (нулл для верхней страницы)
	*/
	function add_page($id, $url_slice, $file_name = NULL, $parent_id = NULL){
		if(in_array($id, $this->id_list) || $id === '404' || $id === 'main_page')
			throw new Exception('Неуникальный ID');
			//return false;
		if(!is_null($file_name) && !$this->check_file($this->pages_path . $file_name))
			throw new Exception('Страница не найдена');
			//return false;
		if(!is_null($parent_id) && !in_array($parent_id, $this->id_list))
			throw new Exception('Родитель не найден');
			//return false;
		if(empty($id) || empty($url_slice)){
			throw new Exception('ID или кусочек URLа пустой');
			//return false;
		}
		
		$data = array('id' => $id, 'url_slice' => $url_slice, 'file_name' => $file_name, 'child' => array(), 'parametres' => array());
		if(is_null($parent_id)){
			if(isset($this->pages[$url_slice]))
				throw new Exception('Кусочек УРЛа образует коллизию');
				//return false;
			$this->pages[$url_slice] = $data;
			$this->id_list[] = $id;
			return true;
		}else{
			return $this->add_child_page($this->pages, $parent_id, $data);
		}
	}
	
	function set_main_page($file_name){
		if(!$this->check_file($this->pages_path . $file_name))
			throw new Exception('Страница не найдена');
			//return false;
		$this->main_page = $file_name;
		return true;
	}
	
	function set_page_404($file_name){
		if(!$this->check_file($this->pages_path . $file_name))
			throw new Exception('Страница не найдена');
			//return false;
		$this->page_404 = $file_name;
		return true;
	}
	
	function set_pages_path($path){
		if(!file_exists($path) || !is_dir($path))
			throw new Exception('Путь не найден');
			//return false;
		$this->pages_path = realpath($path).DIRECTORY_SEPARATOR;
		return true;
	}
	
	function set_parametres($id, $parameter_name, $pos=1){
		if(!in_array($id, $this->id_list)){
			throw new Exception('Несуществующий ID');
			//return false;
		}
		return $this->set_parametres_recursion($id, $parameter_name, $pos, $this->pages);
	}
	
	function set_current_404(){
		$this->current_page = $this->page_404;
		$this->current_id = '404';
	}
	
	function get_main_page(){
		return $this->main_page;
	}
	
	function get_page_404(){
		return $this->page_404;
	}
	
	function get_pages_path(){
		return $this->pages_path;
	}
	
	function get_url(){
		return $this->url;
	}
	
	//возвращает название файла текущей страницу
	function get_current_page(){
		if(!$this->load_current_page())
			return false;
		return $this->current_page;
	}
	
	//возвращает ID текущей страницу
	function get_current_id(){
		if(!$this->load_current_page())
			return false;
		return $this->current_id;
	}
	
	function get_parameter($key){
		return isset($this->current_parametres[$key]) ? $this->current_parametres[$key] : null;
	}
	
	//анализирует УРЛ и устанавливает текущую страницу
	function load_current_page(){
		if($this->current_page !== '')
			return true;
		if(is_null($this->main_page) || is_null($this->page_404))
			throw new Exception('Отсутсвуют главная страница и ошибка 404');
			//return false;
		
		$elements = array_slice(explode('/', $this->url), 1);

		$len = sizeof($elements);
		$pages = $this->pages;
		if($len == 1 && $elements[0] === ''){
			$this->current_page = $this->main_page;
			$this->current_id = 'main_page';
		}else{
			$i=0;
			for($i=0; $i<$len; $i++){
				if($i == $len-1 && $elements[$i] === '')
					break;
				if(isset($pages[$elements[$i]])){
					$this->current_page = $pages[$elements[$i]]['file_name'];
					$this->current_id = $pages[$elements[$i]]['id'];
					if(sizeof($pages[$elements[$i]]['parametres']))
						break;
					$pages = $pages[$elements[$i]]['child'];
				}else{
					$this->set_current_404();
					return true;
				}
			}
			if($this->current_page === '' || is_null($this->current_page)){
				$this->set_current_404();
				return true;
			}
			if($i < $len-1 && sizeof($pages[$elements[$i]]['parametres'])){
				$params = $pages[$elements[$i]]['parametres'];
				ksort($params);
				$params = array_values($params);
				$u = 0;
				for($i = $i+1; $i<$len; $i++, $u++){
					if($i == $len-1 && $elements[$i] === '')
						break;
					if(isset($params[$u])){
						$this->current_parametres[$params[$u]] = $elements[$i];
					}else{
						$this->set_current_404();
						break;
					}
				}
			}
		}
		return true;
	}
	
	//выводит текущую страницу
	function view_current_page($data = array()){
		if(!$this->load_current_page())
			return false;
		echo rad_template($this->pages_path.$this->current_page, $data);
		/*
		$start = microtime(1);
		rad_template($this->pages_path.$this->current_page, $data);
		echo 'rad_template: '.((microtime(1)-$start)*1000).' мсек.'.PHP_EOL;
		$start = microtime(1);
		rad_template_old($this->pages_path.$this->current_page, $data);//быстрее
		echo 'rad_template_old: '.((microtime(1)-$start)*1000).' мсек.'.PHP_EOL;
		*/
		return true;
	}
	
	//проверка на существование файла
	private function check_file($path){
		return file_exists($path) && is_file($path);
	}
	
	//добавляет дочернюю страницу
	private function add_child_page(&$pages, $parent_id, $data){
		foreach($pages as $url => &$page){
			if($page['id'] == $parent_id){
				if(isset($page['child'][$data['url_slice']]))
					throw new Exception('Кусочек УРЛа образует коллизию');
					//return false;
				$page['child'][$data['url_slice']] = $data;
				$this->id_list[] = $data['id'];
				return true;
			}else{
				if($this->add_child_page($page['child'], $parent_id, $data))
					return true;
			}
		}
		return false;
	}
	
	private function set_parametres_recursion($id, $parameter_name, $pos, &$tree){
		foreach($tree as $url_slice => &$page){
			if($page['id'] == $id){
				if(sizeof($page['child']))
					throw new Exception('Не возможно указать параметры родительской странице');
					//return false;
				$page['parametres'][$pos] = $parameter_name;
			}else{
				if($this->set_parametres_recursion($id, $parameter_name, $pos, $page['child']))
					return true;
			}
		}
		return false;
	}
}
?>