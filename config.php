<?php
 
// definiujemy dane do połączenia z bazą danych
define('DBHOST', 'localhost');
define('DBUSER', 'admin_fcis');
define('DBPASS', 'BardzoTrudneHaslo');
define('DBNAME', 'admin_fcis');
 
function db_connect() {
    // połączenie z mysql
    mysql_connect(DBHOST, DBUSER, DBPASS) or die('<h2>ERROR</h2> MySQL Server is not responding');
 
    // wybór bazy danych
    mysql_select_db(DBNAME) or die('<h2>ERROR</h2> Cannot connect to specified database');
}
 
function db_close() {
    mysql_close();
}
 
function clear($text) {
    // jeśli serwer automatycznie dodaje slashe to je usuwamy
    if(get_magic_quotes_gpc()) {
        $text = stripslashes($text);
    }
    $text = trim($text); // usuwamy białe znaki na początku i na końcu
    $text = mysql_real_escape_string($text); // filtrujemy tekst aby zabezpieczyć się przed sql injection
    $text = htmlspecialchars($text); // dezaktywujemy kod html
    return $text;
}
 
function codepass($password) {
    // kodujemy hasło (losowe znaki można zmienić lub całkowicie usunąć
    return sha1(md5($password).'#!%Rgd64');
}
 
// funkcja na sprawdzanie czy user jest zalogowany, jeśli nie to wyświetlamy komunikat
function check_login() {
    if(!$_SESSION['logged']) {
        die('<link rel="stylesheet" type="text/css" href="others.css" media="all"><center><font size="30">
        <p>[<a href="is/login.php">Logowanie</a>] [<a href="is/reg.php">Zarejestruj się</a>]</p>');
    }
}
 
// funkcja na pobranie danych usera
function get_user_data($user_id = -1) {
    // jeśli nie podamy id usera to podstawiamy id aktualnie zalogowanego
    if($user_id == -1) {
        $user_id = $_SESSION['user_id'];
    }
    $result = mysql_query("SELECT * FROM `users` WHERE `user_id` = '{$user_id}' LIMIT 1");
    if(mysql_num_rows($result) == 0) {
        return false;
    }
    return mysql_fetch_assoc($result);
}
 
// startujemy sesje
session_start();
 
// jeśli nie ma jeszcze sesji "logged" i "user_id" to wypełniamy je domyślnymi danymi
if(!isset($_SESSION['logged'])) {
    $_SESSION['logged'] = false;
    $_SESSION['user_id'] = -1;
}
$cracktrack = $_SERVER['QUERY_STRING'];
$wormprotector = array('chr(', 'chr=', 'chr%20', '%20chr', 'wget%20', '%20wget', 'wget(',
'cmd=', '%20cmd', 'cmd%20', 'rush=', '%20rush', 'rush%20',
'union%20', '%20union', 'union(', 'union=', 'echr(', '%20echr', 'echr%20', 'echr=',
'esystem(', 'esystem%20', 'cp%20', '%20cp', 'cp(', 'mdir%20', '%20mdir', 'mdir(',
'mcd%20', 'mrd%20', 'rm%20', '%20mcd', '%20mrd', '%20rm',
'mcd(', 'mrd(', 'rm(', 'mcd=', 'mrd=', 'mv%20', 'rmdir%20', 'mv(', 'rmdir(',
'chmod(', 'chmod%20', '%20chmod', 'chmod(', 'chmod=', 'chown%20', 'chgrp%20', 'chown(', 'chgrp(',
'locate%20', 'grep%20', 'locate(', 'grep(', 'diff%20', 'kill%20', 'kill(', 'killall',
'passwd%20', '%20passwd', 'passwd(', 'telnet%20', 'vi(', 'vi%20',
'insert%20into', 'select%20', 'nigga(', '%20nigga', 'nigga%20', 'fopen', 'fwrite', '%20like', 'like%20',
'$_request', '$_get', '$request', '$get', '.system', 'HTTP_PHP', '&aim', '%20getenv', 'getenv%20',
'new_password', '&icq','/etc/password','/etc/shadow', '/etc/groups', '/etc/gshadow',
'HTTP_USER_AGENT', 'HTTP_HOST', '/bin/ps', 'wget%20', 'uname\x20-a', '/usr/bin/id',
'/bin/echo', '/bin/kill', '/bin/', '/chgrp', '/chown', '/usr/bin', 'g\+\+', 'bin/python',
'bin/tclsh', 'bin/nasm', 'perl%20', 'traceroute%20', 'ping%20', '/usr/X11R6/bin/xterm', 'lsof%20',
'/bin/mail', '.conf', 'motd%20', 'HTTP/1.', '.inc.php', 'config.php', 'cgi-', '.eml',
'file\://', 'window.open', '<SCRIPT>', 'javascript\://','img src', 'img%20src','.jsp','ftp.exe',
'xp_enumdsn', 'xp_availablemedia', 'xp_filelist', 'xp_cmdshell', 'nc.exe', '.htpasswd',
'servlet', '/etc/passwd', 'wwwacl', '~root', '~ftp', '.js', '.jsp', 'admin_', '.history',
'bash_history', '.bash_history', '~nobody', 'server-info', 'server-status', 'reboot%20', 'halt%20',
'powerdown%20', '/home/ftp', '/home/www', 'secure_site, ok', 'chunked', 'org.apache', '/servlet/con',
'<script', '/robot.txt' ,'/perl' ,'mod_gzip_status', 'db_mysql.inc', '.inc', 'select%20from',
'select from', 'drop%20', '.system', 'getenv', 'http_', '_php', 'php_', 'phpinfo()', '<?php', '?>', 'sql=',
'UPDATE', 'DELETE', 'DROP', 'INSERT', '$mysql_', 'java script:');
$checkworm = str_replace($wormprotector, '*', $cracktrack);
  
if($cracktrack != $checkworm)
{
die('Error');
}
?>