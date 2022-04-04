<?php
class rad_data{
	private $data;
	
	function __construct(){
		if(DATA_IN_DB){
			$this->data = array();
		}else{
			$this->data = null;
		}
		$this->load_all();
	}
	
	function load_all(){
		if(DATA_IN_DB){
			$this->load_from_db();
		}else{
			$this->load_from_file();
		}
	}
	
	function get($key){
		if(DATA_IN_DB){
			return $this->get_from_db($key);
		}else{
			return $this->get_from_file($key);
		}
	}
	
	function get_array(){
		$args = func_get_args();
		if(!$args)
			return false;
		if(is_array($args[0])){
			$args = $args[0];
		}
		$ret = array();
		foreach($args as $key){
			$ret[$key] = $this->get($key);
		}
		return $ret;
	}
	
	function update(){
		$args = func_get_args();
		if(!$args)
			return;
		if(is_array($args[0])){
			$args = $args[0];
		}
		if(DATA_IN_DB){
			$this->update_from_db($args);
		}else{
			$this->update_from_file($args);
		}
	}
	
	function update_all(){
		if(DATA_IN_DB){
			$this->update_from_db_all();
		}else{
			$this->update_from_file_all();
		}
	}
	
	function set($key, $value){
		if(is_null($this->data))
			$this->data = array();
		$this->data[$key] = $value;
	}
	
	private function load_from_file(){
		if(file_exists(MAIN_DIR.'data.php')){
			$data = file(MAIN_DIR.'data.php');
			unset($data[0]);
			$this->data = @unserialize(implode('', $data));
		}else{
			$this->data = array();
		}
		/*
		file_put_contents('click_counter.php', '<?php header("Location: ".$_SERVER["SERVER_PROTOCOL"]."://".$_SERVER["HTTP_HOST"]."/");?>'.PHP_EOL . $data);
		*/
	}
	
	private function load_from_db(){
		global $DB;
		
		$res = $DB->getOne("SHOW TABLES FROM ?n like ?s;", MAIN_DBNAME, 'parameters');
		if($res !== false){
			$this->data = $DB->getIndCol('key', "SELECT `key`, `value` FROM `parameters`");
			$len = sizeof($this->data);
			for($i=0; $i < $len; $i++){
				$tmp = @unserialize($this->data[$i]);
				$this->data[$i] = $tmp === false ? $this->data[$i] : $tmp;
			}
		}else{
			$res = $DB->query("CREATE TABLE `parameters` (
				`id` bigint(20) NOT NULL auto_increment,
				`key` tinytext  NOT NULL,
				`value` text    NOT NULL,
				PRIMARY KEY  (`id`)
			)"
			);
			$this->data = array();
		}
	}
	
	private function get_from_db($key){
		if(!$this->data || isset($this->data[$key])){
			global $DB;
			$res = $DB->getRow("SELECT `value` FROM `parameters` WHERE `key` = ?s", $key);
			if($res !== false){
				$tmp = @unserialize($res['value']);
				$this->data[$key] = $tmp === false ? $res['value'] : $tmp;
				return $this->data[$key];
			}else{
				return null;
			}
		}else{
			return $this->data[$key];
		}
	}
	
	private function get_from_file($key){
		if(is_null($this->data)){
			$this->load_from_file();
		}
		return isset($this->data[$key]) ? $this->data[$key] : null;
	}
	
	private function update_from_db($keys){
		global $DB;
		$len = sizeof($keys);
		for($i=0; $i<$len; $i++){
			if(isset($this->data[$keys[$i]])){
				if($DB->getRow("SELECT `value` FROM `parameters` WHERE `key` = ?s", $keys[$i])){
					$DB->query("UPDATE `parameters` SET `value` = ?s WHERE `key` = ?s", serialize($this->data[$keys[$i]]), $keys[$i]);
				}else{
					$DB->query("INSERT INTO `parameters`(`key`, `value`) VALUES(?s, ?s)", $keys[$i], serialize($this->data[$keys[$i]]));
				}
			}else{
				$DB->query("DELETE FROM `parameters` WHERE `key` = ?s", $keys[$i]);
			}
		}
	}
	
	private function update_from_file($keys){
		$len = sizeof($keys);
		$data = array();
		if(file_exists(MAIN_DIR.'data.php')){
			$data = file(MAIN_DIR.'data.php');
			unset($data[0]);
			$data = @unserialize(implode('', $data));
		}
		for($i=0; $i<$len; $i++){
			if(isset($this->data[$keys[$i]])){
				$data[$keys[$i]] = $this->data[$keys[$i]];
			}else{
				unset($data[$keys[$i]]);
			}
		}
		file_put_contents(MAIN_DIR.'data.php', '<?php header("Location: /");?>'.PHP_EOL . serialize($data));
	}
	
	private function update_from_db_all(){
		global $DB;
		$DB->query("TRUNCATE TABLE `parameters`");
		if(!$this->data)
			return;
		$query = "INSERT INTO `parameters`(`key`, `value`) VALUES";
		foreach($this->data as $key => $val){
			$query .= $DB->parse("(?s, ?s), ", $key, serialize($val));
		}
		$query = mb_substr($query, 0, -2);
		$DB->query($query);
	}
	
	private function update_from_file_all(){
		if(!$this->data)
			$this->data = array();
		file_put_contents(MAIN_DIR.'data.php', '<?php header("Location: /");?>'.PHP_EOL . serialize($this->data));
	}
}

?>