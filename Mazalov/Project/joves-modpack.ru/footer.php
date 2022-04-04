<?php
if(!defined('MAIN_DIR'))
	die();
global $URL, $DATA;
?>
			<footer>
                <div class="flex-direction-row">
                    <p class="footer-text" onclick="window.open('https://twitch-prime-wot.ru/')">
                        Twitch Prime
                    </p>
                    <p class="footer-text" onclick="window.open('https://www.youtube.com/user/TheJoves')">
                        Youtube
                    </p>
                    <p class="footer-text" onclick="window.open('https://vk.com/thejoves')">
                        Вконтакте
                    </p>
                    <p class="footer-text" onclick="window.open('https://instagram.com/thejove86')">
                        Instagram
                    </p>
                    <p class="footer-text" onclick="window.location.href='/faq';">
                        Вопрос-Ответ
                    </p>
                </div>
            </footer>
        </div>
<?php if(is_admin()): ?>
		<script src="/scripts/admin_script.js?ver=<?php echo filemtime(MAIN_DIR. 'scripts/admin_script.js'); ?>"></script>
<?php endif; ?>
        <script src="/scripts/script.js?ver=<?php echo filemtime(MAIN_DIR. 'scripts/script.js'); ?>">window.onerror = null;</script>
</body>

</html>