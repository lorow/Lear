<?php
include 'config.php';
db_connect();
 
// sprawdzamy czy user nie jest przypadkiem zalogowany
if(!$_SESSION['logged']) {
    // jeśli zostanie naciśnięty przycisk "Zaloguj"
    if(isset($_POST['name'])) {
        // filtrujemy dane...
        $_POST['name'] = clear($_POST['name']);
        $_POST['password'] = clear($_POST['password']);
        // i kodujemy hasło
        $_POST['password'] = codepass($_POST['password']);
 
        // sprawdzamy prostym zapytaniem sql czy podane dane są prawidłowe
        $result = mysql_query("SELECT `user_id` FROM `users` WHERE `user_name` = '{$_POST['name']}' AND `user_password` = '{$_POST['password']}' LIMIT 1");
        if(mysql_num_rows($result) > 0) {
            // jeśli tak to ustawiamy sesje "logged" na true oraz do sesji "user_id" wstawiamy id usera
            $row = mysql_fetch_assoc($result);
            $_SESSION['logged'] = true;
            $_SESSION['user_id'] = $row['user_id'];

        } else {
            echo '<p><h5>Podany login i/lub hasło jest nieprawidłowe.</p></h5>';
        }
    }
 
    // wyświetlamy komunikat na zalogowanie się
    echo '<form method="post" action="login.php">
        <p>
            <h5>Nazwa serwera:</h5><br>
            <input type="text" value="'.$_POST['name'].'" name="name">
        </p>
        <p>
            <h5>Hasło:</h5><br>
            <input type="password" value="'.$_POST['password'].'" name="password">
        </p>
        <p>
            <input type="submit" value="Zaloguj">
        </p>
    </form>';
} else {
echo '<p>Jesteś już zalogowany, więc nie możesz się zalogować ponownie.</p>
        <p>[<a href="index.php">Powrót</a>]</p>
		<meta http-equiv="refresh" content="1; url=edytuj.php">';
}
 
db_close();
?>
