<?php
if(!defined('MAIN_DIR'))
	die();

if(isset($_REQUEST['action'])){
	$actions = $_REQUEST['action'];
	if(!is_array($actions))
		$actions = array($actions);
	foreach($actions as $act){
		if(function_exists('action_'.$act)){
			call_user_func('action_'.$act);
		}
	}
	
}



function action_update_data(){
	global $DATA;
	//die(print_r($_POST, 1));
	$referer = parse_url($_SERVER['HTTP_REFERER']);
	$request = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
	if($referer['host'] !== $_SERVER['HTTP_HOST'] || $referer['path'] !== '/admin' || ($request !== '/admin' && $request !== '/ajax.php'))
		return false;
	if(!is_admin())
		return false;
	
	$up_data = array(
		'game_version',
		'modpack_version',
		'last_update',
		'download_url_mail',
		'download_url_yandex',
		'download_url_google',
		'download_url_official',
		'warning_text'
	);
	
	upload_modpuck_help();
	
	$len = sizeof($up_data);
	for($i=0; $i<$len; $i++){
		if(isset($_POST[$up_data[$i]])){
			$DATA->set($up_data[$i], $_POST[$up_data[$i]]);
		}else{
			unset($up_data[$i]);
		}
	}
	
	if(isset($_POST['version_history'])){
		$history = validation_html($_POST['version_history']);
		if($history !== false){
			$DATA->set('version_history', $history);
			$up_data[] = 'version_history';
		}
	}
	
	if(isset($_POST['modpuck_prefix'])){
		$prefix = validation_prefix($_POST['modpuck_prefix']);
		if($prefix !== false){
			$DATA->set('modpuck_prefix', $prefix);
			$up_data[] = 'modpuck_prefix';
		}
	}
	
	if(isset($_POST['main_modpuck_version'])){
		$mods_list = get_modpuck_list();
		if(in_array($_POST['main_modpuck_version'], $mods_list['version'])){
			$DATA->set('main_modpuck_version', $_POST['main_modpuck_version']);
			$up_data[] = 'main_modpuck_version';
		}
	}
	
	if(isset($_POST['last_update'])){
		$date = validation_date($_POST['last_update']);
		if($date !== false){
			$DATA->set('last_update', $date);
			$up_data[] = 'last_update';
		}
	}
	
	$DATA->update(array_values($up_data));
	if(isset($_POST['ajax']) && $_POST['ajax'])
		//die(print_r($_POST, 1));
		die();
	if(CLEAR_POST)
		header('Location: /admin');
	return true;
}

function action_exit(){
	if(is_session_exists()){
		session_unset();
		session_destroy();
		setcookie(session_name(), '', time() - 3600*24);
	}
	if(CLEAR_POST)
		header('Location: /admin');
}

function action_click(){
	global $DATA;
	
	$click = $DATA->get('download_click_count');
	$click = $click ? $click+1 : 1;
	$DATA->set('download_click_count', $click);
	$DATA->update('download_click_count');
	echo $click;
	die();
}

function action_get_data(){
	global $DATA;
	
	if(!isset($_REQUEST['options']))
		die();
	$options = $_REQUEST['options'];
	
	$allowed = array(
		'game_version',
		'modpack_version',
		'last_update',
		'download_url_mail',
		'download_url_yandex',
		'download_url_official',
		'download_url_google',
		'modpuck_prefix',
		'main_modpuck_version',
		'warning_text'
	);
	
	$ret = '';
	if(is_array($options)){
		$options = array_intersect($allowed, $options);
		$ret = JSON_encode($DATA->get_array($options));
	}else{
		$ret = in_array($options, $allowed) ? $DATA->get($options) : '';
	}
	die($ret);
}

function action_upload_modpuck(){
	die(JSON_encode(upload_modpuck_help()));
}

function upload_modpuck_help(){
	global $DATA;
	$ret = array();
	if(!is_admin())
		return array('error' => 'Нет доступа');
	
	//$ret['dostup'] = 1;
	
	if(empty($_FILES['modpuck_file']['name']) || is_array($_FILES['modpuck_file']['name']))
		return array('error' => 'Файл отсутствует или их много');
	
	//$ret['files'] = 2;
	
	if($_FILES['modpuck_file']['error'] != UPLOAD_ERR_OK)
		return array('error' => 'Ошибка при загрузке');
	// || !is_uploaded_file($_FILES['modpuck_file']['tmp_name'])
	
	//$ret['upload'] = 3;
	
	$version = '';
	if(!isset($_POST['upload_modpuck_version']) || !strlen($version = validation_filename($_POST['upload_modpuck_version'])))
		return array('error' => 'Отсутствует версия');
	
	//$ret['version'] = 4;
	
	$ext = pathinfo($_FILES['modpuck_file']['name'], PATHINFO_EXTENSION);
	$ext = validation_filename($ext);
	if(!strlen($ext))
		return array('error' => 'Отсутствует расширение');
	
	//$ret['ext'] = 5;
	
	delete_modpuck($version);
	
	if(!move_uploaded_file($_FILES['modpuck_file']['tmp_name'], MAIN_DIR.'modpucks/'.$version.'.'.$ext.'.modpuck'))
		return array('error' => 'Произошла ошибка при копировании');
	
	//$ret['copy'] = 6;
	$DATA->set('main_modpuck_version', $version);
	$DATA->update('main_modpuck_version');
	
	$ret['success']  = 'OK';
	$ret['filesize'] = get_filesize(MAIN_DIR.'modpucks/'.$version.'.'.$ext.'.modpuck');
	$ret['version']  = $version;
	$ret['filename'] = $version.'.'.$ext;
	
	return $ret;
}

function action_check_upload(){
	is_session_exists();
	$ret = array();
	//$ret['post'] = 0;
	if(!isset($_POST[ini_get('session.upload_progress.name')]))
		die(JSON_encode($ret));
	
	//$ret['progress_name'] = 1;
	
	$sess_name = ini_get("session.upload_progress.prefix").$_POST[ini_get('session.upload_progress.name')];
	//$ret['_SESSION'] = $_SESSION;
	//$ret['sess_name'] = $sess_name;
	
	if(!isset($_SESSION[$sess_name]))
		die(JSON_encode($ret));
	
	//$ret['session'] = 2;
	
	if(!is_admin()){
		$_SESSION[$sess_name]['cancel_upload'] = true;
		//$ret['notadmin'] = 3;
	}else{
		//$ret['admin'] = 3;
		$p = (float)($_SESSION[$sess_name]['bytes_processed'] * 100) / $_SESSION[$sess_name]['content_length'];
		$p = round($p, 0);
		$ret['progress'] = $p;
		$ret['bytes_upload'] = $_SESSION[$sess_name]['bytes_processed'];
		//die(JSON_encode(array('progress' => $p, 'bytes_upload' => $_SESSION[$sess_name]['bytes_processed'])));
	}
	die(JSON_encode($ret));
}

function action_cancel_upload(){
	is_session_exists();
	$ret = array();
	//$ret['post'] = 0;
	if(!isset($_POST[ini_get('session.upload_progress.name')]))
		die(JSON_encode($ret));
	
	//$ret['progress_name'] = 1;
	
	$sess_name = ini_get("session.upload_progress.prefix").$_POST[ini_get('session.upload_progress.name')];
	
	if(!isset($_SESSION[$sess_name]))
		die(JSON_encode($ret));
	
	//$ret['session'] = 2;
	
	$_SESSION[$sess_name]['cancel_upload'] = true;
	die(JSON_encode($ret));
}

function action_delete_modpuck(){
	$referer = parse_url($_SERVER['HTTP_REFERER']);
	$request = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
	if($referer['host'] !== $_SERVER['HTTP_HOST'] || $referer['path'] !== '/admin' || ($request !== '/admin' && $request !== '/ajax.php'))
		return false;
	if(!is_admin())
		return false;
	if(!isset($_REQUEST['version']))
		return false;
	delete_modpuck($_REQUEST['version']);
	if(isset($_POST['ajax']) && $_POST['ajax'])
		//die(print_r($_POST, 1));
		die();
	if(CLEAR_POST)
		header('Location: /admin');
}


?>