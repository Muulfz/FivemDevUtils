using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace FivemSetup.Services
{
    public class ArtifactsService
    {
        private string _artifactsUrl;

        public IDictionary<string,Artifact> artifacts { get; private set; }

        public ArtifactsService(string artifactsUrl)
        {
            _artifactsUrl = artifactsUrl;
            artifacts = new Dictionary<string, Artifact>();
            Task.Run((UpdateList));
            
        }

        public async Task<IDictionary<string,Artifact>> UpdateList()
        {
            using (WebClient webClient = new WebClient())
            {
                var artifactsHtml = await webClient.DownloadStringTaskAsync(_artifactsUrl);
                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(artifactsHtml);
                var artifactsNodes = html.DocumentNode.SelectNodes("//*[@id='list']/tbody/tr");
                foreach (var node in artifactsNodes)
                {
                    var childNodes = node.ChildNodes;
                    var nodeText = childNodes.First().InnerText;
                    if (nodeText != "Parent directory/" && nodeText != "revoked/")
                    {
                        var artifactName = nodeText.Replace("/", "").Split("-");

                        artifacts.Add(artifactName[0],new Artifact(Int32.Parse(artifactName[0]), artifactName[1],
                            DateTime.Parse(childNodes.Last().InnerText)));
                    }
                }
            }

            return artifacts;
        }

        public async Task<string> Download(Artifact artifact, string path)
        {
            using (WebClient webClient = new WebClient())
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    
                }
                var url = artifact.url();
                webClient.DownloadProgressChanged += WebClientDownloadProgressChanged;
                var file = $"{path}FivemArtifacts-ID-{artifact.id.ToString()}.zip";
                await webClient.DownloadFileTaskAsync(url, file);
                Console.WriteLine("\b Download finished!");
                return file;
            }
        }
        
        static void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Write("\b\b\b\b\b{0}",  $"{e.ProgressPercentage} %");
        }

    }
    
}