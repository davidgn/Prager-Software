<?php
////////////////////////////////////////////////////////////////////////////
// dB Masters' PHP FormM@iler, Copyright (c) 2005 dB Masters Multimedia
// http://scripts.dbmasters.net/
// FormMailer comes with ABSOLUTELY NO WARRANTY
// Licensed under the AGPL
// See license.txt and readme.txt for details
////////////////////////////////////////////////////////////////////////////
?>
<html>
<head>
<title>dB Masters FormM@iler</title>
</head>
<body>
<form id="form" method="post" action="formmailer.php"> 
<p>Your Name<br /><input type="text" name="Name" value=""/></p> 
<p>Your Email<br /><input type="text" name="Email" value="" /></p> 
<p>Comments and/or Questions<br /><textarea name="Comments" rows="5" cols="40"></textarea></p> 
<p>
<input type="submit" name="submit" value="Submit" /> 
<input type="reset" name="Reset" value="Clear Form" />
<input type="hidden" name="config" value="0" />
</p>
</form> 
<p>Powered by <a href="http://www.dbmasters.net/">dB Masters Multimedia</a> <a href="http://scripts.dbmasters.net/">FormM@iler</a></p>
</body>
</html>