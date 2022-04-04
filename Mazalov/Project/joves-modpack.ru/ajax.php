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

require_once MAIN_DIR.'actions.php';

die('{}');

?>