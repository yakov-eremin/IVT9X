<?php
mb_internal_encoding("UTF-8");
header("Content-Type: text/html; charset=UTF-8");
//setlocale(LC_COLLATE | LC_CTYPE | LC_TIME, 'ru_RU.UTF-8', 'ru_RU', 'ru', 'russian');
define('MAIN_DIR', __DIR__.'/');
require_once MAIN_DIR.'defines.php';

require_once MAIN_DIR.'functions.php';

require_once MAIN_DIR.'includes/db-class.php';
$DB = new rad_db(array('host' => MAIN_DBHOST, 'user' => MAIN_DBUSER, 'pass' => MAIN_DBPASS, 'db' => MAIN_DBNAME));

require_once MAIN_DIR.'includes/data-class.php';
$DATA = new rad_data();
is_session_exists();

require_once MAIN_DIR.'includes/url-class.php';
$URL = new URL();

$URL->set_pages_path($_SERVER['DOCUMENT_ROOT'].'/templates');
$URL->set_main_page('index.html');
$URL->set_page_404('404.html');
$URL->add_page('admin', 'admin', 'admin.html');
$URL->add_page('download', 'download', '404.html');
$URL->set_parametres('download', 'version', 1);
$URL->add_page('faq', 'faq', 'faq.html');
$URL->add_page('contacts', 'contacts', 'contacts.html');
$URL->add_page('changes', 'changes', 'changeScreen.html');
$URL->load_current_page();

require_once MAIN_DIR.'actions.php';

$page_data = array();
if($URL->get_current_id() === 'admin'){
	require_once MAIN_DIR.'admin.php';
}else if($URL->get_current_id() === 'download'){
	if($URL->get_parameter('version')){
		return_modpuck($URL->get_parameter('version'));
		//die($URL->get_parameter('version'));
	}else{
		return_modpuck($DATA->get('main_modpuck_version'));
	}
}else{
	$click_count = $DATA->get('download_click_count')/1000;
	if((int)$click_count > 10000) {
		$click_count = round((float)$click_count / 1000, 1);
	}else{
		$click_count = round((float)$click_count / 1000, 2);
	}
	$yandex = $DATA->get('download_url_yandex');
	$yandex = !empty($yandex) ? '<div id="yandex" onclick="clickCounter();window.open(\''.esc_html($yandex).'\')"></div>' : '';
	$google = $DATA->get('download_url_google');
	$google = !empty($google) ? '<div id="google" onclick="clickCounter();window.open(\''.esc_html($google).'\')"></div>' : '';
	$mail   = $DATA->get('download_url_mail');
	$mail   = !empty($mail) ? '<div id="mail" onclick="clickCounter();window.open(\''.esc_html($mail).'\')"></div>' : '';
	$date = $DATA->get('last_update');
	if(!is_object($date)){
		$tmp = new DateTime($date);
		$date = $tmp !== false ? $tmp : $date;
	}
	if(is_object($date) && get_class($date) === 'DateTime')
		//$date = strftime('%d %b %Y г.', $date->getTimestamp());
		$date = formate_date($date);
	$page_data = array(
		'click_count' => $click_count,
		'game_version' => esc_html($DATA->get('game_version')),
		'modpack_version' => esc_html($DATA->get('modpack_version')),
		'last_update' => $date,
		'download_url_official' => esc_html($DATA->get('download_url_official')),
		'download_yandex' => $yandex,
		'download_google' => $google,
		'download_mail' => $mail,
		'version_history' => $DATA->get('version_history')
	);
}


$URL->view_current_page($page_data);


?>