<?php
function absint($a){
	return abs(intval($a));
}

function esc_html($text){
	return htmlspecialchars($text, ENT_NOQUOTES|ENT_SUBSTITUTE|ENT_HTML401, 'UTF-8', 0);
}

function id_clear($id){
	$id = prefix_clear($id);
	$id = preg_replace('#_+$#', '', $id);
	return strlen($id)? $id : false;
}

function prefix_clear($prefix){
	$prefix = preg_replace('#[^a-zA-Z0-9_]#', '', $prefix);
	$prefix = preg_replace('#^[0-9]+#', '', $prefix);
	return strlen($prefix)? $prefix : false;
}

function file_list($path, $ext='', $name_pattern='^.*?'){
	$files = scandir($path);
	$pattern = '#'.$name_pattern.preg_quote($ext).'$#';
	$len = sizeof($files);
	for($i=0; $i<$len; $i++){
		if(!preg_match($pattern, $files[$i])){
			unset($files[$i]);
		}
	}
	return array_values($files);
}

function include_file($path){
	if(is_file($path)){
		ob_start();
		include $path;
		return ob_get_clean();
	}
	return false;
}

//отсутсвует экранировка
//быстрее
function rad_template_old($file, $data){
	$tpl = file_get_contents($file);
	foreach($data as $key => $value){
		$tpl = str_replace('{'.$key.'}', $value, $tpl);
	}
	return include_file(MAIN_DIR."header.php").$tpl.include_file(MAIN_DIR."footer.php");
}

//имеется экранировка
//медленее
function rad_template($file, $data){
	$tpl = file_get_contents($file);
	$values = array_values($data);
	$vars = array_keys($data);
	$len = sizeof($data);
	for($i=0; $i<$len; $i++){
		$vars[$i] = '#{'.preg_quote($vars[$i], '}').'[^\\\\]?}#u';
	}
	$tpl = preg_replace($vars, $values, $tpl);
	$tpl = str_replace('\\}', '}', $tpl);
	return include_file(MAIN_DIR."header.php").$tpl.include_file(MAIN_DIR."footer.php");
}

function check_admin(){
	global $DATA;
	if(is_admin()){
		return true;
	}
	if(isset($_POST['login'], $_POST['password'])){
		if(strcasecmp(trim($_POST['login']), $DATA->get('admin_login')) === 0 && sha1(SALT.$_POST['password']) === $DATA->get('admin_password')){
			if(!is_session_exists())
				my_start_session();
			$_SESSION['admin'] = true;
			if(CLEAR_POST)
				header('Location: /admin');
			return true;
		}else{
			return false;
		}
	}
	return false;
}

function is_admin(){
	//die(is_session_exists());
	if(is_session_exists()){
		return isset($_SESSION['admin']) && $_SESSION['admin'];
	}else{
		return false;
	}
}

function is_session_exists(){
	if(!session_id() && (isset($_REQUEST[session_name()]) || isset($_COOKIE[session_name()]))){
	//if(!session_id() && isset($_REQUEST[session_name()])){
		$sessid = isset($_REQUEST[session_name()]) ? $_REQUEST[session_name()] : '';
		if(!$sessid)
			$sessid = $_COOKIE[session_name()];
		session_id($sessid);
		my_start_session();
		if(empty($_SESSION)){
			session_destroy();
			return false;
		}
		return true;
	}else if(session_id()){
		return true;
	}
	return false;
}

function my_start_session(){
	$params = session_get_cookie_params();
	$params['httponly'] = true;
	session_set_cookie_params($params['lifetime'], $params['path'], $params['domain'], $params['secure'], $params['httponly']);
	
	session_start();
}

//TODO: доделать валидацию хтмл
function validation_html($html){
	return $html;
}

function validation_date($date_str){
	$date = new DateTime();
	$date = $date->createFromFormat('Y-m-d', $date_str);
	if($date === false)
		return false;
	return $date->format('Y-m-d') === $date_str ? $date : false;
}

function formate_date($date){
	$months = array(
		'янв.',
		'фев.',
		'мар.',
		'апр.',
		'мая',
		'июн.',
		'июл.',
		'авг.',
		'сен.',
		'окт.',
		'ноя.',
		'дек.'
	);
	
	$date_arr = getdate($date->getTimestamp());
	return $date_arr['mday'].' '.$months[$date_arr['mon']-1].' '.$date_arr['year'].' г.';
}

function return_modpuck($version){
	global $DATA;
	$mods_list = get_modpuck_list();
	$key = array_search($version, $mods_list['version']);
	if($key === false)
		return false;
	return file_force_download(MAIN_DIR.'modpucks/'.$mods_list['filename'][$key].'.modpuck', $DATA->get('modpuck_prefix').$mods_list['filename'][$key]);
}

function validation_filename($filename){
	$filename = preg_replace('#[^a-zA-Z0-9\\.\\-_]#u', '', $filename);
	$filename = trim($filename, '.-_');
	return $filename;
}

function validation_prefix($prefix){
	$prefix = preg_replace('#[^a-zA-Z0-9\\.\\-_]#u', '', $prefix);
	$prefix = ltrim($prefix, '.-_');
	return $prefix;
}

function get_modpuck_list(){
	$list = glob(MAIN_DIR.'modpucks/*.modpuck');
	$len = sizeof($list);
	$ret = array('filename' => array(), 'version' => array());
	for($i=0; $i<$len; $i++){
		$ret['filename'][$i] = pathinfo($list[$i], PATHINFO_FILENAME);
		$ret['version'][$i] = preg_replace('#\\.[^\\.]*$#u', '', $ret['filename'][$i]);
	}
	return $ret;
}

function delete_modpuck($version){
	$list = get_modpuck_list();
	$key = array_search($version, $list['version']);
	if($key !== false){
		unlink(MAIN_DIR.'modpucks/'.$list['filename'][$key].'.modpuck');
		return true;
	}else{
		return false;
	}
}

function get_protocol(){
	if((isset($_SERVER['REQUEST_SCHEME']) && $_SERVER['REQUEST_SCHEME'] === 'https') || (isset($_SERVER['HTTPS']) && $_SERVER['HTTPS'] === 'on')){
		return 'https';
	}else{
		return 'http';
	}
}

function file_force_download($path, $filename){
	if(!file_exists($path))
		return false;
	$filename = validation_filename($filename);
	if($filename == '')
		return false;
	if(ob_get_level())
		ob_end_clean();
	
	// заставляем браузер показать окно сохранения файла
	header('Content-Description: File Transfer');
	header('Content-Type: application/octet-stream');
	header('Content-Disposition: attachment; filename='.$filename);
	header('Content-Transfer-Encoding: binary');
	header('Expires: 0');
	header('Cache-Control: must-revalidate');
	header('Pragma: public');
	header('Content-Length: ' . filesize($path));
	// читаем файл и отправляем его пользователю
	readfile($path);
	exit;
}

function get_filesize($path){
	if(!file_exists($path))
		return false;
	$size = filesize($path);
	$unit = 'b';
	
	if($size > 1024){
		$size = (float) $size / 1024;
		$unit = 'Kb';
	}
	
	if($size > 1024){
		$size = (float) $size / 1024;
		$unit = 'Mb';
	}
	
	if($size > 1024){
		$size = (float) $size / 1024;
		$unit = 'Gb';
	}
	
	if($size < 100){
		$size = round($size, 2);
	}else if($size < 1000){
		$size = round($size, 1);
	}else{
		$size = round($size, 0);
	}
	
	return $size.' '.$unit;
}

?>