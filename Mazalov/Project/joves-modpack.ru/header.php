<?php
if(!defined('MAIN_DIR'))
	die();
global $URL, $DATA;

?>
<!DOCTYPE html>
<html>

<head>
	<meta charset="UTF-8" />
	<meta name="keywords" content="модпак, джова, джов, jove, joves, jove's, world of tanks, вот, wot, ворлд оф танкс, ворлд оф тэнкс, патч, 1.9, modpack, скачать, официальный сайт, последняя версия" />
	<meta name="author" content="Jove" />
	<meta name="copyright" lang="en" content="Jove" />
	<meta name="description" content="Модпак самого популярного блогера по игре World Of Tanks. Лучшие моды – прицелы, декали, озвучки, удобные панели, просмотр брони в ангаре и ещё куча модов уже ждут тебя. Скачивай и наслаждайся крутым геймплеем!" />
	<meta name="resource-type" content="document" />
	<meta name="robots" content="all" />
	<meta title="Скачать Модпак Джова к патчу 1.12 - Официальный Сайт" />
	<!--Описание надо заполнить -->
	<title>Модпак Джова – Официальный сайт</title>
	<link rel="icon" type="image/ico" href="favicon.png" />
	<link rel="stylesheet" href="/libs/bootstrap-4.3.1-dist/css/bootstrap.min.css">
	<link rel="stylesheet" href="/styles/style.css?ver=91" />
	<script src="/libs/jquery.min.js"></script>
<?php if($URL->get_current_id() === 'admin'): ?>
	<link rel="stylesheet" href="/styles/admin_style.css?ver=<?php echo filemtime(MAIN_DIR. 'styles/admin_style.css'); ?>" />
<?php endif; ?>
<?php if(is_admin()): ?>
	<link rel="stylesheet" href="/libs/CodeMirror-5.19.0/lib/codemirror.css" />
	<link rel="stylesheet" href="/libs/CodeMirror-5.19.0/theme/lesser-dark.css" />
	<script src="/libs/CodeMirror-5.19.0/lib/codemirror.js"></script>
	<script src="/libs/CodeMirror-5.19.0/mode/htmlmixed/htmlmixed.js"></script>
	<script src="/libs/CodeMirror-5.19.0/mode/css/css.js"></script>
	<script src="/libs/CodeMirror-5.19.0/mode/javascript/javascript.js"></script>
	<script src="/libs/CodeMirror-5.19.0/mode/xml/xml.js"></script>
	<script src="/libs/CodeMirror-5.19.0/addon/edit/matchbrackets.js"></script>
	<script src="/libs/CodeMirror-5.19.0/addon/edit/closetag.js"></script>
	<script src="/libs/CodeMirror-5.19.0/addon/selection/active-line.js"></script>
	<script src="/libs/jquery.maskedinput.min.js"></script>
	<script src="/libs/jquery.min.js"></script>
	<script src="/scripts/script.js"></script>
<?php else: ?>
	<!-- Yandex.Metrika counter -->
	<script type="text/javascript">
		(function (m, e, t, r, i, k, a) {
		m[i] = m[i] || function () { (m[i].a = m[i].a || []).push(arguments) };
			m[i].l = 1 * new Date(); k = e.createElement(t), a = e.getElementsByTagName(t)[0], k.async = 1, k.src = r, a.parentNode.insertBefore(k, a)
		})
			(window, document, "script", "https://mc.yandex.ru/metrika/tag.js", "ym");

		ym(62244358, "init", {
			clickmap: true,
			trackLinks: true,
			accurateTrackBounce: true,
			webvisor: true
		});
	</script>
	<noscript>
		<div><img src="https://mc.yandex.ru/watch/62244358" style="position:absolute; left:-9999px;" alt="" /></div>
	</noscript>
	<!-- /Yandex.Metrika counter -->
<?php endif; ?>
</head>

<body>
    <a target="_blank"><div id="overlay"></div></a>
    <div class="close" id="click-close"></div>
	<div class="container">
		<div class="main-wrapper">
		    <div class="volod9"></div>
            <a href="https://twitch-prime-wot.ru/" class="mobile-adab" target="_blank"><div class="ads-window"></div></a>
			<div class="header-buttons float-right">
				<input type="button" class="link-button" value="Twitch Prime"
					onclick="window.open('https://twitch-prime-wot.ru/')" />
				<input type="button" class="download-button" value="Скачать"
					onclick="clickCounter();window.open('<?php echo esc_html($DATA->get('download_url_official')); ?>');" /> <!-- Так же -->
			</div>
			<div class="row">
				<div class="col-md-12 col-lg-12 col-sm-12">
					<div class="main-title">
						<div class="flex-direction-row justify-content-space-between">
							<div class="flex-direction-row">
								<div class="image-part"<?php if($URL->get_current_id() != 'main_page') echo ' onclick="window.location.href=\'/\';"'; ?>></div>
								<p class="title"<?php if($URL->get_current_id() != 'main_page') echo ' onclick="window.location.href=\'/\';"'; ?>
									style="cursor: pointer;">Модпак Джова</p>
								<div class="line-block">
									<div class="white-line"></div>
									<p class="second-text">
										Лучшая сборка модов для World Of Tanks
									</p>
								</div>
							</div>
							<div class="social-wrapper">
								<div class="icon" id="youtube"
									onclick="window.open('https://www.youtube.com/user/TheJoves')"></div>
								<div class="icon" id="vk" onclick="window.open('https://vk.com/thejoves')">
								</div>
								<div class="icon" id="instagram"
									onclick="window.open('https://instagram.com/thejove86')"></div>
							</div>
						</div>
					</div>
					<div class="col-md-12 col-lg-12 col-sm-12">
						<div class="white-header">
							<div class="pages flex-direction-row">
								<div class="brigt">
									<span class="page"<?php if($URL->get_current_id() != 'main_page') echo ' onclick="window.location.href=\'/\';"'; ?>>Главная</span>
								</div>
								<div class="brigt">
									<span class="page" id="active" onclick="window.open('https://twitch-prime-wot.ru/')">Twitch Prime</span>
								</div>
								<div class="brigt">
									<span class="page"<?php if($URL->get_current_id() != 'faq') echo ' onclick="window.location.href=\'/faq\';"'; ?>>Вопрос-Ответ</span>
								</div>
								<div class="brigt">
									<span class="page"<?php if($URL->get_current_id() != 'contacts') echo ' onclick="window.location.href=\'/contacts\';"'; ?>>Контакты</span>
								</div>
<?php
	if(is_admin()){
		echo '<div class="brigt"><span class="page"';
		if($URL->get_current_id() != 'admin')
			echo ' onclick="window.location.href=\'/admin\';"';
		echo '>Админка</span></div>';
	}
?>
							</div>
						</div>
					</div>
					<?php echo ($DATA->get('warning_text') && $URL->get_current_id() == 'main_page' ? '<div class="warn-wrapper"><p>'.esc_html($DATA->get('warning_text')).'</p></div>' : ''); ?>
				</div>
			</div>