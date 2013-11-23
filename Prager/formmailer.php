<?php
////////////////////////////////////////////////////////////////////////////
// dB Masters' PHP FormM@iler, Copyright (c) 2004 dB Masters Multimedia
// FormMailer comes with ABSOLUTELY NO WARRANTY
// Licensed under the AGPL
// See license.txt and readme.txt for details
////////////////////////////////////////////////////////////////////////////
// General Variables
	$check_referrer="no";
	$referring_domains="http://domain.com/,http://www.domain.com/,http://subdomain.domain.com/";

// Default Error and Success Page Variables
	$error_page_title="Error - Missed Fields";
	$error_page_text="Please use your browser's back button to return to the form and complete the required fields.";
	$thanks_page_title="The Problem Report has been sent.";
	$thanks_page_text="Thank you for your submission; we will get back to you regarding the resolution.";

// options to use if hidden field "config" has a value of 0
// recipient info
	$charset[0]="iso-8859-1";
	$tomail[0]="support@pragersoftware.com";
	$cc_tomail[0]="";
	$bcc_tomail[0]="";
// Mail contents config
	$subject[0]="Problem Report";
	$reply_to_field[0]="Email";
	$required_fields[0]="Name,SoftwarePackage,Problem,OperatingSystem,SPLevel,Description,ProgramVersion";
	$required_email_fields[0]="Email";
	$attachment_fields[0]="Attachment";
	$return_ip[0]="no";
	$mail_intro[0]="The following is a Problem Report:\n";
	$mail_fields[0]="SoftwarePackage,ProgramVersion,Problem,OperatingSystem,SPLevel,ISBN,Description,Name,Email";
	$mail_type[0]="vert_table";
	$mail_priority[0]="1";
// Send back to sender config
	$send_copy[0]="no";
	$send_copy_format[0]="vert_table";
	$send_copy_fields[0]="Name,Comments";
	$send_copy_attachment_fields[0]="";
	$copy_subject[0]="Subject of Copy Email";
	$copy_intro[0]="Thank you for your submission, the following message has been delivered.";
	$copy_from[0]="noreply@yourdomain.com";
	$copy_tomail_field[0]="Email";
// Result options
	$header[0]="";
	$footer[0]="";
	$error_page[0]="";
	$thanks_page[0]="";

// options to use if hidden field "config" has a value of 1
// recipient info
	$charset[1]="";
	$tomail[1]="";
	$cc_tomail[1]="";
	$bcc_tomail[1]="";
// Mail contents config
	$subject[1]="";
	$reply_to_field[1]="";
	$required_fields[1]="";
	$required_email_fields[1]="";
	$attachment_fields[1]="";
	$return_ip[1]="";
	$mail_intro[1]="";
	$mail_fields[1]="";
	$mail_type[1]="";
	$mail_priority[1]="";
// Send back to sender config
	$send_copy[1]="";
	$send_copy_format[1]="";
	$send_copy_fields[1]="";
	$send_copy_attachment_fields[1]="";
	$copy_subject[1]="";
	$copy_intro[1]="";
	$copy_from[1]="";
	$copy_tomail_field[1]="";
// Result options
	$header[1]="";
	$footer[1]="";
	$error_page[1]="";
	$thanks_page[1]="";

/////////////////////////////////////////////////////////////////////////
// Don't muck around past this line unless you know what you are doing //
/////////////////////////////////////////////////////////////////////////

ob_start();
$config=$_POST["config"];
$reply_to_field=$reply_to_field[$config];
$copy_tomail_field=$copy_tomail_field[$config];

if($header[$config]!="")
	include($header[$config]);

if($_POST["submit"] || $_POST["Submit"] || $_POST["submit_x"] || $_POST["Submit_x"])
{

////////////////////////////
// begin global functions //
////////////////////////////
// get visitor IP
	function getIP()
	{
		if(getenv(HTTP_X_FORWARDED_FOR))
			$user_ip=getenv("HTTP_X_FORWARDED_FOR");
		else
			$user_ip=getenv("REMOTE_ADDR");
		return $user_ip;
	}
// get value of given key
	function parseArray($key)
	{
		$array_value=$_POST[$key];
		$count=1;
		extract($array_value);
		foreach($array_value as $part_value)
		{
			if($count > 1){$value.=", ";}
			$value.=$part_value;
			$count=$count+1;
		}
		return $value;
	}
// stripslashes and autolink url's
	function parseValue($value)
	{
		$value=preg_replace("/(http:\/\/+.[^\s]+)/i",'<a href="\\1">\\1</a>', $value);
		return $value;
	}
// html header if used
	function htmlHeader()
	{
		$htmlHeader="<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\">\n<html>\n<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=".$charset[$config]."\"></head>\n<body>\n<table cellpadding=\"2\" cellspacing=\"0\" border=\"0\" width=\"600\">\n";
		return $htmlHeader;
	}
// html footer if used
	function htmlFooter()
	{
		$htmlFooter="</table>\n</body>\n</html>\n";
		return $htmlFooter;
	}
// build verticle table format
	function buildVertTable($fields, $intro, $to, $send_ip)
	{
		$message=htmlHeader();
		if($intro != "")
			$message.="<tr>\n<td align=\"left\" valign=\"top\" colspan=\"2\">".$intro."</td>\n</tr>\n";
		$fields_check=preg_split('/,/',$fields);
		$run=sizeof($fields_check);
		for($i=0;$i<$run;$i++)
		{
			$cur_key=$fields_check[$i];
			$cur_value=$_POST[$cur_key];
			if(is_array($cur_value))
			{
				$cur_value=parseArray($cur_key);
			}
			$cur_value=parseValue($cur_value);
			$message.="<tr>\n<td align=\"left\" valign=\"top\" style=\"white-space:nowrap;\"><b>".$cur_key."</b></td>\n<td align=\"left\" valign=\"top\" width=\"100%\">".nl2br($cur_value)."</td>\n</tr>\n";
		}
		if($send_ip=="yes" && $to=="recipient")
		{
			$user_ip=getIP();
			$message.="<tr>\n<td align=\"left\" valign=\"top\" style=\"white-space:nowrap;\"><b>Sender IP</b></td>\n<td align=\"left\" valign=\"top\" width=\"100%\">".$user_ip."</td>\n</tr>\n";
		}
		$message.=htmlFooter();
		return $message;
	}
// build horizontal table format
	function buildHorzTable($fields, $intro, $to, $send_ip)
	{
		$message=htmlHeader();
		$fields_check=preg_split('/,/',$fields);
		$run=sizeof($fields_check);
		if($intro != "")
			$message.="<tr>\n<td align=\"left\" valign=\"top\" colspan=\"".$run."\">".$intro."</td>\n</tr>\n";
		$message.="<tr>\n";
		for($i=0;$i<$run;$i++)
		{
			$cur_key=$fields_check[$i];
			$message.="<td align=\"left\" valign=\"top\" style=\"white-space:nowrap;\"><b>".$cur_key."</b></td>\n";
		}
		if($send_ip=="yes" && $to=="recipient")
			$message.="<td align=\"left\" valign=\"top\" style=\"white-space:nowrap;\"><b>Sender IP</b></td>\n";
		$message.="</tr>\n";
		$message.="<tr>\n";
		for($i=0;$i<$run;$i++)
		{
			$cur_key=$fields_check[$i];
			$cur_value=$_POST[$cur_key];
			if(is_array($cur_value))
			{
				$cur_value=parseArray($cur_key);
			}
			$cur_value=parseValue($cur_value);
			$message.="<td align=\"left\" valign=\"top\">".nl2br($cur_value)."</td>\n";
		}
		$message.="</tr>\n";
		$message.="<tr>\n";
		if($send_ip=="yes" && $to=="recipient")
		{
			$user_ip=getIP();
			$message.="<td align=\"left\" valign=\"top\">".$user_ip."</td>\n";
		}
		$message.="</tr>\n";
		$message.=htmlFooter();
		return $message;
	}
// build plain text format
	function buildTextTable($fields, $intro, $to, $send_ip)
	{
		$message="";
		if($intro != "")
			$message.=$intro."\n\n";
		$fields_check=preg_split('/,/',$fields);
		$run=sizeof($fields_check);
		for($i=0;$i<$run;$i++)
		{
			$cur_key=$fields_check[$i];
			$cur_value=$_POST[$cur_key];
			if(is_array($cur_value))
			{
				$cur_value=parseArray($cur_key);
			}
			$cur_value=parseValue($cur_value);
			$message.="".$cur_key.": ".$cur_value."\n\n";
		}
		if($send_ip=="yes" && $to=="recipient")
		{
			$user_ip=getIP();
			$message.="Sender IP: ".$user_ip."\n";
		}
		return $message;
	}
// get the proper build fonction
	function buildTable($format, $fields, $intro, $to, $send_ip)
	{
		if($format=="vert_table")
			$message=buildVertTable($fields, $intro, $to, $send_ip);
		else if($format=="horz_table")
			$message=buildHorzTable($fields, $intro, $to, $send_ip);
		else
			$message=buildTextTable($fields, $intro, $to, $send_ip);
		return $message;
	}
// referrer checking security option
	function checkReferer()
	{
		if($check_referrer=="yes")
		{
			$ref_check=preg_split('/,/',$referring_domains);
			$ref_run=sizeof($ref_check);
			$referer=$_SERVER['HTTP_REFERER'];
			$domain_chk="no";
			for($i=0;$i<$ref_run;$i++)
			{
				$cur_domain=$ref_check[$i];
				if(stristr($referer,$cur_domain)){$domain_chk="yes";}
			}
		}
		else
		{
			$domain_chk="yes";
		}
		return $domain_chk;
	}
// checking required fields and email fields
	function checkFields($text_fields, $email_fields, $reply_to_field)
	{
      	$error_message="";
		if($text_fields != "")
		{
			$req_check=preg_split('/,/',$text_fields);
			$req_run=sizeof($req_check);
			for($i=0;$i<$req_run;$i++)
			{
				$cur_field_name=$req_check[$i];
				$cur_field=$_POST[$cur_field_name];
				if($cur_field=="")
				{
					$error_message.="<li>You are missing the <b>".$req_check[$i]."</b> field</li>\n";
				}
			}
		}
		if($email_fields != "")
		{
			$email_check=preg_split('/,/',$email_fields);
			$email_run=sizeof($email_check);
			for($i=0;$i<$email_run;$i++)
			{
				$cur_email_name=$email_check[$i];
				$cur_email=$_POST[$cur_email_name];
				if($cur_email=="" || !eregi("^[-a-z0-9!#$%&\'*+/=?^_`{|}~]+(\.[-a-z0-9!#$%&\'*+/=?^_`{|}~]+)*@(([a-z]([-a-z0-9]*[a-z0-9]+)?){1,63}\.)+([a-z]([-a-z0-9]*[a-z0-9]+)?){2,63}$",$cur_email))
				{
					$error_message.="<li>You are missing the <b>".$email_check[$i]."</b> field or it is not a valid email address.</li>\n";
				}
			}
		}
		return $error_message;
	}
// attachment function
	function getAttachments($attachment_fields, $message, $content_type, $border)
	{
		$att_message="This is a multi-part message in MIME format.\n\n";
		$att_message.="--{$border}\n";
		$att_message.=$content_type."\n";
		$att_message.="Content-Transfer-Encoding: 7bit\n\n";
		$att_message.=$message."\n\n";

		$att_check=preg_split('/,/',$attachment_fields);
		$att_run=sizeof($att_check);
		for($i=0;$i<$att_run;$i++)
		{
			$fileatt=$_FILES[$att_check[$i]]['tmp_name'];
			$fileatt_name=$_FILES[$att_check[$i]]['name'];
			$fileatt_type=$_FILES[$att_check[$i]]['type'];
			if (is_uploaded_file($fileatt))
			{
				$file=fopen($fileatt,'rb');
				$data=fread($file,filesize($fileatt));
				fclose($file);
				$data=chunk_split(base64_encode($data));
				$att_message.="--{$border}\n";
				$att_message.="Content-Type: {$fileatt_type}; name=\"{$fileatt_name}\"\n";
				$att_message.="Content-Disposition: attachment; filename=\"{$fileatt_name}\"\n";
				$att_message.="Content-Transfer-Encoding: base64\n\n".$data."\n\n";
			}
		}
		$att_message.="--{$border}--\n";
		return $att_message;
	}
// function to set content type
	function contentType($charset, $format)
	{
		if($format=="vert_table")
			$content_type="Content-type: text/html; charset=\"".$charset."\"\n";
		else if($format=="horz_table")
			$content_type="Content-type: text/html; charset=\"".$charset."\"\n";
		else
			$content_type="Content-type: text/plain; charset=\"".$charset."\"\n";
		return $content_type;
	}
//////////////////////////
// end global functions //
//////////////////////////

////////////////////////////////
// begin procedural scripting //
////////////////////////////////
	$domain_chk=checkReferer();
	if($domain_chk=="yes")
	{
		$error_message=checkFields($required_fields[$config], $required_email_fields[$config], $reply_to_field[$config]);
		if($error_message=="")
		{
// build appropriate message format for recipient
			$content_type=contentType($charset[$config], $mail_type[$config]);
			$message=buildTable($mail_type[$config], $mail_fields[$config], $mail_intro[$config], "recipient", $return_ip[$config]);
// build header data for recipient message
			$extra="From: ".$_POST[$reply_to_field]."\n";
			if($cc_tomail[$config]!="")
				$extra.="Cc: ".$cc_tomail[$config]."\n";
			if($bcc_tomail[$config]!="")
				$extra.="Bcc: ".$bcc_tomail[$config]."\n";
			$extra.="X-Priority: ".$mail_priority[$config]."\n";
// get attachments if necessary
			if($attachment_fields[$config]!="")
			{
				$semi_rand=md5(time());
				$border="==Multipart_Boundary_x{$semi_rand}x";
				$extra.="MIME-Version: 1.0\n";
				$extra.="Content-Type: multipart/mixed; boundary=\"{$border}\"";
				$message=getAttachments($attachment_fields[$config], $message, $content_type, $border);
			}
			else
			{
				$extra.="MIME-Version: 1.0\n".$content_type;
			}
// send recipient email
			mail("".$tomail[$config]."", "".stripslashes($subject[$config])."", "".stripslashes($message)."", "$extra");
// autoresponse email if necessary
			if($send_copy[$config]=="yes")
			{
// build appropriate message format for autoresponse
				$content_type=contentType($charset[$config], $send_copy_format[$config]);
				$message=buildTable($send_copy_format[$config], $send_copy_fields[$config], $copy_intro[$config], "autoresponder", $return_ip[$config]);
// build header data for autoresponse
				$copy_tomail=$_POST[$copy_tomail_field];
				$copy_extra="From: ".$copy_from[$config]."\n";
// get autoresponse  attachments if necessary
				if($send_copy_attachment_fields[$config]!="")
				{
					$semi_rand=md5(time());
					$border="==Multipart_Boundary_x{$semi_rand}x";
					$copy_extra.="MIME-Version: 1.0\n";
					$copy_extra.="Content-Type: multipart/mixed; boundary=\"{$border}\"";
					$message=getAttachments($send_copy_attachment_fields[$config], $message, $content_type, $border);
				}
				else
				{
					$copy_extra.="MIME-Version: 1.0\n".$content_type;
				}
// send autoresponse email
				$send_copy = 1;
				if($copy_tomail=="" || !eregi("^[-a-z0-9!#$%&\'*+/=?^_`{|}~]+(\.[-a-z0-9!#$%&\'*+/=?^_`{|}~]+)*@(([a-z]([-a-z0-9]*[a-z0-9]+)?){1,63}\.)+([a-z]([-a-z0-9]*[a-z0-9]+)?){2,63}$",$copy_tomail))
					$send_copy = 0;
				if($send_copy == 1)
					mail("$copy_tomail", "".$copy_subject[$config]."", "$message", "$copy_extra");
			}
// showing thanks pages from a successful submission
			if($thanks_page[$config]=="")
			{
				echo "<p>$thanks_page_title</p>\n";
				echo "<p>$thanks_page_text</p>\n";
			}
			else
			{
				header("Location: ".$thanks_page[$config]);
			}
		}
		else
		{
// entering error page options from missing required fields
			if($error_page[$config]=="")
			{
				echo "<p>$error_page_title</p>\n";
				echo "<ul>\n";
				echo $error_message;
				echo "</ul>\n";
				echo "<p>$error_page_text</p>\n";
			}
			else
			{
				header("Location: ".$error_page[$config]);
			}
		}
	}
	else
	{
// message if unauthorized domain trigger from referer checking option
		echo "<p>Sorry, mailing request came from an unauthorized domain.</p>\n";
	}
//////////////////////////////
// end procedural scripting //
//////////////////////////////

}
else
{
	echo "<p>Error</p>";
	echo "<p>No form data has been sent to the script</p>\n";
}
if($footer[$config]!="")
	include($footer[$config]);
ob_end_flush();
?>
