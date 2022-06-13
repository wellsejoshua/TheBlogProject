using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProject.ViewModels
{
  public class MailSettings
  {
    //stores smtp settings mail data from google. So we can configure and use smtp server from google for example
    public string Mail { get; set; }
    //to use alias to make it look like it comes from a different person
    public string DisplayName { get; set; }
    public string Password { get; set; }
    //smtp server
    public string Host { get; set; }
    //holds port number
    public int Port { get; set; }

  }
}
