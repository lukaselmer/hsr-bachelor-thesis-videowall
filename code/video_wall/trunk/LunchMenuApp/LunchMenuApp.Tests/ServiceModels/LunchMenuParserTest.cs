using Microsoft.VisualStudio.TestTools.UnitTesting;
using LunchMenuApp.ServiceModels;

namespace LunchMenuApp.Tests.ServiceModels
{
    /// <summary>
    ///This is a test class for LunchMenuParserTest and is intended
    ///to contain all LunchMenuParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LunchMenuParserTest
    {
        #region TestHtml
        private static string _html = @"<?xml version=""1.0"" encoding=""utf-8""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">

<!--[if lt IE 7 ]> <html xmlns=""http://www.w3.org/1999/xhtml"" class=""ie6""> <![endif]-->

<!--[if IE 7 ]>    <html xmlns=""http://www.w3.org/1999/xhtml"" class=""ie7""> <![endif]-->

<!--[if IE 8 ]>    <html xmlns=""http://www.w3.org/1999/xhtml"" class=""ie8""> <![endif]-->

<!--[if IE 9 ]>    <html xmlns=""http://www.w3.org/1999/xhtml"" class=""ie9""> <![endif]-->

<!--[if (gte IE 9)|!(IE)]><!-->
<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""de"" lang=""de"">
<!--<![endif]-->

<head>

<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
<!-- 
    concept, design and production by Netvertising AG, Zurich, Switzerland

    This website is powered by TYPO3 - inspiring people to share!
    TYPO3 is a free open source Content Management Framework initially created by Kasper Skaarhoj and licensed under GNU/GPL.
    TYPO3 is copyright 1998-2009 of Kasper Skaarhoj. Extensions are copyright of their respective owners.
    Information and contribution at http://typo3.com/ and http://typo3.org/
-->




<meta name=""generator"" content=""TYPO3 4.3 CMS"" />
<meta name=""robots"" content=""index,follow"" />






<script type=""text/javascript"">
/*<![CDATA[*/
<!-- 
/*_scriptCode*/
var browserName=navigator.appName;var browserVer=parseInt(navigator.appVersion);var version="""";var msie4=(browserName==""Microsoft Internet Explorer""&&browserVer>=4);if((browserName==""Netscape""&&browserVer>=3)||msie4||browserName==""Konqueror""||browserName==""Opera""){version=""n3"";}else{version=""n2"";}
function blurLink(theObject){if(msie4){theObject.blur();}}
function decryptCharcode(n,start,end,offset){n=n+offset;if(offset>0&&n>end){n=start+(n-end-1);}else if(offset<0&&n<start){n=end-(start-n-1);}
return String.fromCharCode(n);}
function decryptString(enc,offset){var dec="""";var len=enc.length;for(var i=0;i<len;i++){var n=enc.charCodeAt(i);if(n>=0x2B&&n<=0x3A){dec+=decryptCharcode(n,0x2B,0x3A,offset);}else if(n>=0x40&&n<=0x5A){dec+=decryptCharcode(n,0x40,0x5A,offset);}else if(n>=0x61&&n<=0x7A){dec+=decryptCharcode(n,0x61,0x7A,offset);}else{dec+=enc.charAt(i);}}
return dec;}
function linkTo_UnCryptMailto(s){location.href=decryptString(s,-2);}
// -->
/*]]>*/
</script>

<base href=""http://hochschule-rapperswil.sv-group.ch/"" /><title>Menuplan - Mensa HSR Hochschule Rapperswil</title><!-- pageid=9207--><meta name=""keywords"" content="",Mensa HSR Hochschule Rapperswil, Rapperswil, Mensa, HSR Hochschule Rapperswil, SV (Schweiz) AG, SV Schweiz, SV, SV Business, Betriebsverpflegung, Mitarbeiterverpflegung, Personalgastronomie, Catering, Verpflegung, gesunde Verpflegung, Reservation, Bestellung, Angebot, Preise, SV Restaurants, Personalrestaurant, Personalrestaurants, Gaststätte, Kantine, Getränke, Oeffnungszeiten, Betriebsrestaurant, Bankett, Partyservice, Kaffee, Gerichte, preiswert, Menukarte, Fleisch, Fisch, Gemuese, Speisekarte, Sitzplätze, Take-away, Nichtraucher, Service, Self-service, self service, Selbstbedienung, Mittagessen, Fruehstueck, Essen, Gaeste, Menu, Tagesteller, Restaurant, Restaurants, vegetarisch, kreativ, guenstig, Spezialitaeten"" /><meta name=""description"" content="" Mensa HSR Hochschule Rapperswil, Rapperswil, Mensa, SV (Schweiz) AG, SV Schweiz, SV, SV Business, Betriebsverpflegung, Mitarbeiterverpflegung, Personalgastronomie, Catering, Verpflegung, gesunde Verpflegung, Reservation, Bestellung, Angebot, Preise, SV Res"" />

    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />

    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />

    <meta http-equiv=""imagetoolbar"" content=""no""/>

    <link rel=""shortcut icon"" href=""/favicon.ico"" type=""image/x-icon"">

    

    <script src=""fileadmin/templates/sv-business-red/htmltmpl/js/jquery-1.7.1.min.js"" type=""text/javascript""></script>

        

    <!-- WEBFONT START -->

    <script type=""text/javascript"">
        /* NETVERTISING DEVELOPEMENT ACCOUNT START */
        /* var WebFontConfigProjectId = '64ad9a7c-4f4d-4155-ba82-2112716b9a6b'; */
        /* NETVERTISING DEVELOPEMENT ACCOUNT END */
        /* SV ONLINE ACCOUNT START */
        var WebFontConfigProjectId = '3f61822d-ddc5-4c90-8a58-8ca1a0a3164b';
        /* SV ONLINE ACCOUNT END */
        WebFontConfig = {
            monotype: {
                projectId: WebFontConfigProjectId
            },
            active: function () {
                var $ambienceNavigation = jQuery('.ambience-navigation');
                if ($ambienceNavigation.length > 0) {
                    var $ambienceNavigationLevel1 = $ambienceNavigation.find('ul.horizontal');
                    var $ambienceNavigationLevel2 = $ambienceNavigation.find('ul.vertical');

                    var ambienceNavigationLevelWidth = Math.max($ambienceNavigationLevel1.width(), $ambienceNavigationLevel2.width()) + 20;
                    $ambienceNavigationLevel1.width(ambienceNavigationLevelWidth);
                    $ambienceNavigationLevel2.width(ambienceNavigationLevelWidth);

                    $ambienceNavigation.on(""mouseover"", function () {
                        $ambienceNavigationLevel1.addClass('mouseIsOver');
                        $ambienceNavigationLevel2.show();
                    }).on(""mouseout"", function () {
                        $ambienceNavigationLevel1.removeClass('mouseIsOver');
                        $ambienceNavigationLevel2.hide();
                    });
                }
            }
        };

        (function () {
            var wf = document.createElement('script');
            wf.src = ('https:' == document.location.protocol ? 'https' : 'http') +
                '://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
            wf.type = 'text/javascript';
            wf.async = 'true';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(wf, s);
        })();

    </script>

    <noscript>

        <link href=""http://fast.fonts.com/cssapi/3f61822d-ddc5-4c90-8a58-8ca1a0a3164b.css"" rel=""stylesheet"" type=""text/css"" />

    </noscript>

    <!-- WEBFONT END -->



    <link href=""fileadmin/templates/sv-business-red/htmltmpl/css/style.css"" rel=""stylesheet"" type=""text/css"" media=""all"" />	

    

    <script src=""fileadmin/templates/sv-business-red/htmltmpl/js/group_nav.js"" type=""text/javascript""></script>

    



<script type=""text/javascript"">
    /*<![CDATA[*/
<!--
        // JS function for mouse-over
    function over(name,imgObj)	{	//
        if (version == ""n3"" && document[name]) {document[name].src = eval(name+""_h.src"");}
        else if (document.getElementById && document.getElementById(name)) {document.getElementById(name).src = eval(name+""_h.src"");}
        else if (imgObj)	{imgObj.src = eval(name+""_h.src"");}
    }
        // JS function for mouse-out
    function out(name,imgObj)	{	//
        if (version == ""n3"" && document[name]) {document[name].src = eval(name+""_n.src"");}
        else if (document.getElementById && document.getElementById(name)) {document.getElementById(name).src = eval(name+""_n.src"");}
        else if (imgObj)	{imgObj.src = eval(name+""_n.src"");}
    }

// -->
    /*]]>*/
</script>

<script type=""text/javascript"">
    /*<![CDATA[*/
<!--
if (version == ""n3"") {
img_9497_0_n=new Image(); img_9497_0_n.src = ""typo3temp/menu/e6a98991e7.png""; 
img_9497_0_h=new Image(); img_9497_0_h.src = ""typo3temp/menu/614ddcaecd.png"";
}
// -->
    /*]]>*/
</script>

</head>
<body class=""de"">

    

    <div id=""centercontent"">

    

        <div class=""navigation-group shaddow-container-top"">

        

            <div class=""navigation-group-inner"" style=""position:relative;"">

                <div id=""groupNavFade"" style=""position: relative; top: -26px;"" class=""""><script type=""text/javascript"">

                        <!--
                                                                                            document.write('<div style=""display: none;"" id=""groupNavFadeDisplayNone"">');	

                        // -->

                    </script>

                    <div style=""position:absolute; right: 0px; z-index:4; top: 26px;""><a href=""http://www.sv-group.ch"" target=""_self"" onfocus=""blurLink(this);"" onmouseover=""over('img_9497_0');"" onmouseout=""out('img_9497_0');""  ><img src=""typo3temp/menu/e6a98991e7.png"" width=""200"" height=""25"" border=""0"" alt=""SV Group"" name=""img_9497_0"" /></a></div>

                    <script type=""text/javascript"">

                        <!--
                        document.write('</div>');	

                        // -->

                    </script></div>

            </div>

        </div>

        

        <div id=""content""><div class=""header""><div class=""restaurant-name""><h1><a href=""de/menuplan.html"" onfocus=""blurLink(this);""  >Mensa HSR Hochschule Rapperswil</a></h1></div><div class=""logo""><a href=""de/menuplan.html"" onfocus=""blurLink(this);""  ><img src=""fileadmin/templates/sv-business-red/htmltmpl/images/logo.gif"" width=""158"" height=""48"" border=""0"" alt="""" title="""" /></a></div></div><div class=""ambience-container""><div class=""header-slideshow""><ul id=""header-slideshow-uid-9207""><li id=""slideshow-uid-9207-slide-1"" class=""active""><img src=""typo3temp/pics/b28440bf46.jpg"" width=""775"" height=""230"" border=""0"" alt="""" title="""" /></li><li id=""slideshow-uid-9207-slide-2"" style=""display:none;""><img src=""typo3temp/pics/8346547dae.jpg"" width=""775"" height=""230"" border=""0"" alt="""" title="""" /></li><li id=""slideshow-uid-9207-slide-3"" style=""display:none;""><img src=""typo3temp/pics/4ffba606c5.jpg"" width=""775"" height=""230"" border=""0"" alt="""" title="""" /></li><li id=""slideshow-uid-9207-slide-4"" style=""display:none;""><img src=""typo3temp/pics/b2144fe625.jpg"" width=""775"" height=""230"" border=""0"" alt="""" title="""" /></li><li id=""slideshow-uid-9207-slide-5"" style=""display:none;""><img src=""typo3temp/pics/13b703b1bd.jpg"" width=""775"" height=""230"" border=""0"" alt="""" title="""" /></li></ul></div>
                <script type=""text/javascript"">
                    /**
                    * function SlideShow 
                    */
                    var slideShowAnimationInProgress = false;
                    var slideShowFadeDuration = 2000;
                    var slideShowBreakDuration = 7000;
                    var slideFirstShowBreakDuration = 3500;
                    function showSlide(mode, slideShowId) {
                        slideshow_id = slideShowId;
                        if (!slideShowAnimationInProgress && jQuery(""#"" + slideshow_id).length > 0) {
                            var $active = jQuery(""#"" + slideshow_id + "" li.active"").length ? jQuery(""#"" + slideshow_id + "" li.active"") : jQuery(""#"" + slideshow_id + "" li:last"");
                            var $next = $active.next().length ? $active.next() : jQuery(""#"" + slideshow_id + "" li:first"");

                            $active.css(""position"", ""absolute"");
                            $next.css(""position"", ""absolute"");

                            $active.addClass(""last-active"");

                            slideShowAnimationInProgress = true;
                            $next.hide().addClass(""active"").animate(
                            {
                                opacity: ""show""
                            }, slideShowFadeDuration, function () {
                                $active.removeClass(""active last-active"");
                                $active.hide();
                                slideShowAnimationInProgress = false;
                                window.setTimeout(function () { showSlide(mode, slideShowId) }, slideShowBreakDuration);
                            });
                        }
                    }

                    function initSlideShows() {
                        var slideShowId;
                        var slideShowHeight;
                        var itemHeight;

                        jQuery("".header-slideshow"").each(function () {
                            slideShowHeight = 0;

                            var $slideShow = jQuery(this);
                            var $slideShowItemsContainer = $slideShow.find(""ul:first"");
                            slideShowId = $slideShowItemsContainer.attr(""id"");

                            $slideShowItemsContainer.find(""li"").each(function () {
                                var $item = jQuery(this);
                                if ($item.is("":hidden"")) {
                                    $item.data(""wasHidden"", 1);
                                    $item.show();
                                }

                                //ascertained the slideShow heightest element
                                itemHeight = $item.height();
                                if (slideShowHeight < itemHeight) {
                                    slideShowHeight = itemHeight;
                                }
                                if ($item.data(""wasHidden"")) {
                                    $item.hide();
                                }
                            });
                            //set the slideShow height
                            $slideShowItemsContainer.height(slideShowHeight);


                            window.setTimeout(function () { showSlide(""next"", slideShowId); }, slideFirstShowBreakDuration);
                        });
                    }

                    initSlideShows();
                </script>
            </div><div class=""content-container""><div class=""left-col"" style=""float:left;""><div class=""left-nav""><ul><li class=""first act""><a href=""de/menuplan.html"" onfocus=""blurLink(this);""  >Menuplan</a></li><li class=""middle""><a href=""de/ueber-uns.html"" onfocus=""blurLink(this);""  >Über uns</a></li><li class=""middle""><a href=""de/catering.html"" onfocus=""blurLink(this);""  >Catering</a></li><li class=""middle""><a href=""de/feedback.html"" onfocus=""blurLink(this);""  >Feedback</a></li><li class=""last""><a href=""de/kontakt.html"" onfocus=""blurLink(this);""  >Kontakt</a></li></ul></div><a name=""c50522""></a><div class=""content-title""><h2>Öffnungszeiten</h2></div><div class=""content-text""><p class=""bodytext"">Montag - Freitag<br />7.00 - 16.00 Uhr</p></div><a name=""c50540""></a><div class=""content-title""><h2>Related link</h2></div><div class=""linklist"">

                        <div class=""linklist-innerwrap"">

                            <div class=""border-line""><img src=""/clear.gif"" width=""1"" height=""1"" alt="""" /></div>

                            <div class=""linklist-link""><a href=""http://www.hsr.ch"" target=""_blank"" class=""link-extern""><span class=""icon icon-linklist""></span>HSR Hochschule für Technik Rapperswil</a></div>

                            <div class=""border-line""><img src=""/clear.gif"" width=""1"" height=""1"" alt="""" /></div>

                        </div>

                    </div></div><div class=""content-col"" style=""float:left;""><div class=""content-title special""><h1>Menuplan</h1></div><div class=""content-navigation-empty""></div><a name=""c50538""></a><div class=""html-menu""><div class=""menu-plan-content""><div class=""menu-plan-metanav""><a href=""uploads/tx_netvsvgmenu/7700/2012W20-ge_7700.pdf"" target=""_blank"" onfocus=""this.blur();"" target=""_blank"" onFocus=""blurLink(this);"">Menuplan W20 als PDF</a><span class=""pipe"">&#124;</span><a class=""menuplan-newsletter-link"" href=""javascript:;"" onfocus=""this.blur();"" onclick=""if($(this).nextAll().is('#menu-newsletter_1-toggler')){$(this).toggleClass('act');$('#menu-newsletter_1-toggler').slideToggle();}else{$('a.menuplan-newsletter-link').removeClass('act');$(this).addClass('act');$('#menu-newsletter_1-toggler').hide().insertAfter($(this)).slideDown();}"">Menu-Newsletter</a>

            <script src=""/typo3conf/ext/netv_svg_menu/js/tx_netvsvgmenu_nslsubs.js"" type=""text/javascript""></script>

            <div class=""menu-newsletter"" id=""menu-newsletter_1-toggler"" style=""display:none;"">

                <div class=""menu-newsletter-inner"">

                    <div class=""content-title""><h2>Menu-Newsletter</h2></div>

                    <div id=""menu-newsletter_1"">

                        <p class=""bodytext"">Erhalten Sie unser Menuangebot als Newsletter.</p>

                        <div class=""menu-newsletter-form"">

                            <input type=""text"" class=""text"" id=""menu-nlemailfield_1"" value=""Ihre E-Mail-Adresse"" onFocus=""if(!this.initialyCleared){this.value='';this.initialyCleared=true;}"">

                            <input class=""b-submit-mini"" type=""image"" src=""/fileadmin/templates/sv-business-red/htmltmpl/images/b_submit-mini.gif"" 

                                onClick=""var email = document.getElementById('menu-nlemailfield_1').value;

                                    loadNewsletterSubs('menu-newsletter_1',

                                        '&step=1&elcounter=1&email=' + email + '&branch=7700&lang=0&sendday_pdf=0',

                                        '/typo3conf/ext/netv_svg_menu/htmlmenu/addSubscriber.php');"">

                        </div>

                    </div>

                </div>

            </div>

            </div><script type=""text/javascript"">

                <!--
                      $('.menu-plan-metanav:first').prependTo($('.content-col'));

                    

                // -->

            </script><div class=""date""><h2>Freitag, 18.05.2012</h2></div><div class=""date-selector""><a href=""de/menuplan.html?addGP%5Bweekday%5D=5&amp;addGP%5Bweekmod%5D=0"" target=""_self"" class=""act"">Freitag</a></div><div class=""add-to-calendar""><a href=""de/menuplan.html?addGP%5Bweekday%5D=5&amp;addGP%5Bweekmod%5D=0&amp;addGP%5Bcalender%5D=1"" onfocus=""this.blur();""><span class=""icon icon-calendar""></span>Einladung in meinem Terminkalender erstellen</a></div><div class=""offer""><div class=""offer-description""> - Take-away - </div><a href=""javascript:;"" onClick=""window.open('/fileadmin/content/takeaway/?branchident=7700&lang=ge', 'takeaway', 'width=520,height=670,scrollbars=yes');return false;"" onfocus=""this.blur();"" target=""_blank"">Take-away - Bestellformular</a></div><div class=""divider""><img src=""/clear.gif"" alt="""" /></div><div class=""offer"">

                        <div class=""offer-description"">

                            Tagesteller

                        </div>

                        

                        <div class=""menu-description"">

                            <div class=""maindish"">Thai-Fischröllchen<br />
auf Wokgemüse<br />
Sweet & Sour<br />
Jasminreis<br />
Fisch das Dänemark/Pazifik</div>

                        </div>

                    <div class=""price""><span class=""price-item"">INT 8.00</span> <span class=""price-item"">EXT 10.60</span></div>

                    <div class=""social-network"">

                        <a href=""https://www.facebook.com/sharer.php?u=http%3A%2F%2Fhochschule-rapperswil.sv-group.ch%2Fsocial.php%3Fpath%3D%25252Fde.html%26date%3D20120518%26title%3DMensa%2520Hochschule%2520f%25C3%25BCr%2520Technik%2520Rapperswil%26description%3DThai-Fischr%25C3%25B6llchen%2520auf%2520Wokgem%25C3%25BCse%2520Sweet%2520%2526%2520Sour%2520Jasminreis%2520Fisch%2520das%2520D%25C3%25A4nemark%252FPazifik"" target=""_blank""><span class=""icon icon-facebook""></span></a>

                        <a href=""http://twitter.com/intent/tweet?text=http%3A%2F%2Fgoo.gl%2FAXpjp%20Mensa%20Hochschule%20f%C3%BCr%20Technik%20Rapperswil%20-%20Thai-Fischr%C3%B6llchen%20auf%20Wokgem%C3%BCse%20Sweet%20%26%20Sour%20Jasminreis%20Fisch%20das..."" target=""_blank""><span class=""icon icon-twitter""></span></a>

                        <span class=""google-plusone""><g:plusone size=""small"" annotation=""none"" href=""http://hochschule-rapperswil.sv-group.ch/social.php?path=%2Fde.html&date=20120518&title=Mensa%20Hochschule%20f%C3%BCr%20Technik%20Rapperswil&description=Thai-Fischr%C3%B6llchen%20auf%20Wokgem%C3%BCse%20Sweet%20%26%20Sour%20Jasminreis%20Fisch%20das%20D%C3%A4nemark%2FPazifik""></g:plusone></span>

                    </div>

                    <div class=""specials-logo""><a href=""http://www.sv-group.ch/liveeasy-corp"" target=""_self""><span class=""icon icon-liveeasy""></span></a></div></div><div class=""divider""><img src=""/clear.gif"" alt="""" /></div><div class=""offer"">

                        <div class=""offer-description"">

                            Vegetarisch

                        </div>

                        

                        <div class=""menu-description"">

                            <div class=""maindish"">Kartoffelquarktaschen mit <br />
Wokgemüse<br />
und Tomatensauce<br />
<br />
Menüsalat</div>

                        </div>

                    <div class=""price""><span class=""price-item"">INT 8.00</span> <span class=""price-item"">EXT 10.60</span></div>

                    <div class=""social-network"">

                        <a href=""https://www.facebook.com/sharer.php?u=http%3A%2F%2Fhochschule-rapperswil.sv-group.ch%2Fsocial.php%3Fpath%3D%25252Fde.html%26date%3D20120518%26title%3DMensa%2520Hochschule%2520f%25C3%25BCr%2520Technik%2520Rapperswil%26description%3DKartoffelquarktaschen%2520mit%2520%2520Wokgem%25C3%25BCse%2520und%2520Tomatensauce%2520%2520Men%25C3%25BCsalat"" target=""_blank""><span class=""icon icon-facebook""></span></a>

                        <a href=""http://twitter.com/intent/tweet?text=http%3A%2F%2Fgoo.gl%2FAXpjp%20Mensa%20Hochschule%20f%C3%BCr%20Technik%20Rapperswil%20-%20Kartoffelquarktaschen%20mit%20%20Wokgem%C3%BCse%20und%20Tomatensauce%20%20Men%C3%BCsalat"" target=""_blank""><span class=""icon icon-twitter""></span></a>

                        <span class=""google-plusone""><g:plusone size=""small"" annotation=""none"" href=""http://hochschule-rapperswil.sv-group.ch/social.php?path=%2Fde.html&date=20120518&title=Mensa%20Hochschule%20f%C3%BCr%20Technik%20Rapperswil&description=Kartoffelquarktaschen%20mit%20%20Wokgem%C3%BCse%20und%20Tomatensauce%20%20Men%C3%BCsalat""></g:plusone></span>

                    </div>

                    </div><div class=""divider""><img src=""/clear.gif"" alt="""" /></div><div class=""offer"">

                        <div class=""offer-description"">

                            Täglich im Angebot

                        </div>

                        

                        <div class=""menu-description"">

                            <div class=""maindish"">Dauerbrenner <br />
<br />
Rinds-Hamburger <br />
(Schweiz)<br />
mit Barbeque-Sauce</div>

                        </div>

                    <div class=""price""><span class=""price-item"">INT 8.00</span> <span class=""price-item"">EXT 10.60</span></div>

                    <div class=""social-network"">

                        <a href=""https://www.facebook.com/sharer.php?u=http%3A%2F%2Fhochschule-rapperswil.sv-group.ch%2Fsocial.php%3Fpath%3D%25252Fde.html%26date%3D20120518%26title%3DMensa%2520Hochschule%2520f%25C3%25BCr%2520Technik%2520Rapperswil%26description%3DDauerbrenner%2520%2520%2520Rinds-Hamburger%2520%2520%2528Schweiz%2529%2520mit%2520Barbeque-Sauce"" target=""_blank""><span class=""icon icon-facebook""></span></a>

                        <a href=""http://twitter.com/intent/tweet?text=http%3A%2F%2Fgoo.gl%2FAXpjp%20Mensa%20Hochschule%20f%C3%BCr%20Technik%20Rapperswil%20-%20Dauerbrenner%20%20%20Rinds-Hamburger%20%20%28Schweiz%29%20mit%20Barbeque-Sauce"" target=""_blank""><span class=""icon icon-twitter""></span></a>

                        <span class=""google-plusone""><g:plusone size=""small"" annotation=""none"" href=""http://hochschule-rapperswil.sv-group.ch/social.php?path=%2Fde.html&date=20120518&title=Mensa%20Hochschule%20f%C3%BCr%20Technik%20Rapperswil&description=Dauerbrenner%20%20%20Rinds-Hamburger%20%20%28Schweiz%29%20mit%20Barbeque-Sauce""></g:plusone></span>

                    </div>

                    </div><div class=""divider""><img src=""/clear.gif"" alt="""" /></div><div class=""offer"">

                        <div class=""offer-description"">

                            Wochen-Hit

                        </div>

                        

                        <div class=""menu-description"">

                            <div class=""maindish"">Portion Spargel<br />
aus Flaach von <br />
der Familie Spaltenstein<br />
mit Sauce Hollandaise<br />
und Kräuterkartoffeln<br />
Menüsalat</div>

                        </div>

                    <div class=""price""><span class=""price-item"">INT 14.50</span> <span class=""price-item"">EXT 15.50</span></div>

                    <div class=""social-network"">

                        <a href=""https://www.facebook.com/sharer.php?u=http%3A%2F%2Fhochschule-rapperswil.sv-group.ch%2Fsocial.php%3Fpath%3D%25252Fde.html%26date%3D20120518%26title%3DMensa%2520Hochschule%2520f%25C3%25BCr%2520Technik%2520Rapperswil%26description%3DPortion%2520Spargel%2520aus%2520Flaach%2520von%2520%2520der%2520Familie%2520Spaltenstein%2520mit%2520Sauce%2520Hollandaise%2520und%2520Kr%25C3%25A4uterkartoffeln%2520Men%25C3%25BCsalat"" target=""_blank""><span class=""icon icon-facebook""></span></a>

                        <a href=""http://twitter.com/intent/tweet?text=http%3A%2F%2Fgoo.gl%2FAXpjp%20Mensa%20Hochschule%20f%C3%BCr%20Technik%20Rapperswil%20-%20Portion%20Spargel%20aus%20Flaach%20von%20%20der%20Familie%20Spaltenstein%20mit%20Sauce..."" target=""_blank""><span class=""icon icon-twitter""></span></a>

                        <span class=""google-plusone""><g:plusone size=""small"" annotation=""none"" href=""http://hochschule-rapperswil.sv-group.ch/social.php?path=%2Fde.html&date=20120518&title=Mensa%20Hochschule%20f%C3%BCr%20Technik%20Rapperswil&description=Portion%20Spargel%20aus%20Flaach%20von%20%20der%20Familie%20Spaltenstein%20mit%20Sauce%20Hollandaise%20und%20Kr%C3%A4uterkartoffeln%20Men%C3%BCsalat""></g:plusone></span>

                    </div>

                    <div class=""specials-logo""><a href=""http://www.sv-group.ch/liveeasy-corp"" target=""_self""><span class=""icon icon-liveeasy""></span></a></div></div><div class=""mwst"">Preise in CHF inkl. MWST</div><div class=""menu-plan-metanav menu-plan-footer""><a href=""uploads/tx_netvsvgmenu/7700/2012W20-ge_7700.pdf"" target=""_blank"" onfocus=""this.blur();"" target=""_blank"" onFocus=""blurLink(this);"">Menuplan W20 als PDF</a><span class=""pipe"">|</span><a class=""menuplan-newsletter-link"" href=""javascript:;"" onfocus=""this.blur();"" onclick=""if($(this).nextAll().is('#menu-newsletter_1-toggler')){$(this).toggleClass('act');$('#menu-newsletter_1-toggler').slideToggle();}else{$('a.menuplan-newsletter-link').removeClass('act');$(this).addClass('act');$('#menu-newsletter_1-toggler').hide().insertAfter($(this)).slideDown();}"">Menu-Newsletter</a></div></div></div><!-- end htmlmenu --><div id=""footer""><div class=""recommend""><div class=""left-col"" style=""float:left;""><a href=""javascript:window.print();"">Drucken</a><span class=""pipe"">&#124;</span><a href=""de/spezialseiten/tell-a-friend.html?rpageuid=9207"" onfocus=""blurLink(this);""  >Tell a friend</a></div><div class=""right-col"" style=""float:right;""><span>Seite des Restaurants weiterempfehlen</span><span class=""fb-share"">

                                            <iframe src=""http://www.facebook.com/plugins/like.php?locale=en_US&href=http://hochschule-rapperswil.sv-group.ch/&send=false&layout=button_count&width=85&show_faces=false&action=like&colorscheme=light&height=21"" scrolling=""no"" frameborder=""0"" style=""border:none; overflow:hidden; width:85px; height:21px;"" allowTransparency=""true""></iframe>

                                        </span><div class=""social-network""><a href=""https://www.facebook.com/sharer.php?u=http://hochschule-rapperswil.sv-group.ch"" target=""_blank"" onfocus=""this.blur();""><span class=""icon icon-facebook""></span></a><a href=""http://twitter.com/intent/tweet?text=http%3A%2F%2Fhochschule-rapperswil.sv-group.ch"" target=""_blank"" onfocus=""this.blur();""><span class=""icon icon-twitter""></span></a><span class=""google-plusone""><g:plusone size=""small"" annotation=""none"" href=""http://hochschule-rapperswil.sv-group.ch""></g:plusone></span><script type=""text/javascript"">
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     window.___gcfg = { lang: ""de"" };

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     (function () {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         var po = document.createElement(""script""); po.type = ""text/javascript""; po.async = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         po.src = ""https://apis.google.com/js/plusone.js"";
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         var s = document.getElementsByTagName(""script"")[0]; s.parentNode.insertBefore(po, s);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     })();

                                            </script></div></div><div style=""clear:both;""><img src=""/clear.gif"" alt="""" /></div></div><div class=""restaurant-info""><div class=""left-col"" style=""float:left;"">Mensa HSR Hochschule Rapperswil</div><div class=""right-col"" style=""float:left;"">&copy;&nbsp;2012<span class=""pipe"">&#124;</span><a href=""de/spezialseiten/disclaimer.html"" onfocus=""blurLink(this);""  >Disclaimer</a></div><div style=""clear:both;""><img src=""/clear.gif"" alt="""" /></div></div></div></div><div style=""clear:both;""><img src=""/clear.gif"" alt="""" /></div></div></div>

    </div>

<!-- LINKTRACKER --><script src=""/fileadmin/templates/sv-group/htmltmpl/js/gatag.js"" type=""text/javascript""></script><!-- analyze micro.sv-group.ch --><script type=""text/javascript"">                                                                                                                                                           var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www.""); document.write(unescape(""%3Cscript src='"" + gaJsHost + ""google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E""));</script><script type=""text/javascript"">                                                                                                                                                                                                                                                                                                                                                                                                                            try { var pageTracker = _gat._getTracker(""UA-1431446-2""); pageTracker._setDomainName(""none""); pageTracker._setAllowLinker(true); pageTracker._trackPageview(); } catch (e) { }</script>




</body>
</html>";
        #endregion

        /// <summary>
        ///A test for LunchMenuParser Constructor
        ///</summary>
        [TestMethod]
        public void LunchMenuParserConstructorTest()
        {
            var parser = new LunchMenuParser_Accessor(_html);
            Assert.IsNotNull(parser._menuNode);
        }

        /// <summary>
        ///A test for ExtractDate
        ///</summary>
        [TestMethod]
        public void ExtractDateTest()
        {
            var parser = new LunchMenuParser(_html);
            Assert.AreEqual("Freitag, 18.05.2012", parser.ExtractDate());
        }

        /// <summary>
        ///A test for ExtractMenus
        ///</summary>
        [TestMethod]
        public void ExtractMenusTest()
        {
            var parser = new LunchMenuParser(_html);
            var dishes = parser.ExtractMenus();

            Assert.AreEqual(4, dishes.Count);
            
            // Test dish #1
            Assert.AreEqual("Tagesteller", dishes[0].Type);
            Assert.AreEqual(@"Thai-Fischröllchen
auf Wokgemüse
Sweet & Sour
Jasminreis
Fisch das Dänemark/Pazifik", dishes[0].Name);
            Assert.AreEqual("INT 8.00 EXT 10.60", dishes[0].Price);

            // Test dish #2
            Assert.AreEqual("Vegetarisch", dishes[1].Type);
            Assert.AreEqual(@"Kartoffelquarktaschen mit 
Wokgemüse
und Tomatensauce

Menüsalat", dishes[1].Name);
            Assert.AreEqual("INT 8.00 EXT 10.60", dishes[1].Price);

            // Test dish #3
            Assert.AreEqual("Täglich im Angebot", dishes[2].Type);
            Assert.AreEqual(@"Dauerbrenner 

Rinds-Hamburger 
(Schweiz)
mit Barbeque-Sauce", dishes[2].Name);
            Assert.AreEqual("INT 8.00 EXT 10.60", dishes[2].Price);

            // Test dish #4
            Assert.AreEqual("Wochen-Hit", dishes[3].Type);
            Assert.AreEqual(@"Portion Spargel
aus Flaach von 
der Familie Spaltenstein
mit Sauce Hollandaise
und Kräuterkartoffeln
Menüsalat", dishes[3].Name);
            Assert.AreEqual("INT 14.50 EXT 15.50", dishes[3].Price);
        }
    }
}
