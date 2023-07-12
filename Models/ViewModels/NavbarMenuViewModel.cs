using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiserverTraining.Models.ViewModels
{
    public class NavbarMenuViewModel
    {
        public List<Navigation> MainNavigation { get; set; }
    }
    public class Navigation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<Navigation> SubNavigation { get; set; }
    }
}