using System;
using System.Collections.Generic;

namespace BrowserApp.Data
{
    public class BrowserContents
    {
        public List<BrowserContent> Urls { get; private set; }

        public BrowserContents()
        {
            Urls = new List<BrowserContent>
                     {
                         new YoutubeContent("BE_Nk-HjsRc", TimeSpan.FromSeconds(150)),
                         new YoutubeContent("QZUwvpL2bME", TimeSpan.FromSeconds(15)),
                         new BrowserContent{Type = BrowserContentType.Url, Content="http://127.0.0.1:3000", Duration = TimeSpan.FromSeconds(3)},
                         new BrowserContent{Type = BrowserContentType.Url, Content="http://google.com", Duration = TimeSpan.FromSeconds(3)},
                         new BrowserContent{Type = BrowserContentType.Html, Content="Hello <b>World</b>", Duration = TimeSpan.FromSeconds(3)},
                         new BrowserContent{Type = BrowserContentType.Html, Content="Huhu!!!", Duration = TimeSpan.FromSeconds(7)},
                         new BrowserContent{Type = BrowserContentType.Html, Content="<i>Tuc</i>", Duration = TimeSpan.FromSeconds(1)},
                     };
        }
    }

    public class YoutubeContent : BrowserContent
    {
       /* #region Template

        string _template = @"<html>
  <head>
    <!--<script src=""http://www.youtube.com/player_api""></script>-->
  </head>
  <body>
    <!-- 1. The <iframe> (and video player) will replace this <div> tag. -->
    <div style=""text-align: center; margin-top: 100px;"">
      <div id=""player""></div>
    </div>

    <script>
      // 2. This code loads the IFrame Player API code asynchronously.
      var tag = document.createElement('script');
      tag.src = ""http://www.youtube.com/player_api"";

      var firstScriptTag = document.getElementsByTagName('script')[0];
      firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

      // 3. This function creates an <iframe> (and YouTube player)
      //    after the API code downloads.
      var player;
      function onYouTubePlayerAPIReady() {
        player = new YT.Player('player', {
          height: '720',
          width: '1280',
          videoId: '{{VIDEO_ID}}',
          playerVars: { 'autoplay': 1, 'controls': 0, 'showinfo': 0 },
          events: {
            'onReady': onPlayerReady
            //'onStateChange': onPlayerStateChange
          },
          playbackQuality: ""hd720""
        });
      }

      // 4. The API will call this function when the video player is ready.
      function onPlayerReady(event) {
        event.target.playVideo();
        event.target.setPlaybackQuality(""highres"");
      }
    </script>

  </body>
</html>";

        #endregion
        */

        private const string Template = "http://www.youtube.com/embed/{{VIDEO_ID}}?enablejsapi=1&autoplay=1&controls=0&showinfo=0;";

        public YoutubeContent(string theyoutubekey, TimeSpan duration)
        {
            Type = BrowserContentType.Url;
            Duration = duration;
            Content = Template.Replace("{{VIDEO_ID}}", theyoutubekey);
        }
    }

    public enum BrowserContentType
    {
        Html, Url
    }

    public class BrowserContent
    {
        public BrowserContentType Type { get; set; }

        public string Content { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
