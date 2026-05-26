using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Domain.Entity
{
    public class ProjectRequest : Common<int>
    {

        #region ` Consructor '

        private ProjectRequest()
        {
        }
        public ProjectRequest(string title, string summary, string location, string phoneNumber)
        {
            Title = title;
            Summary = summary;
            Location = location;
            PhoneNumber = phoneNumber;
        }

        #endregion ` Consructor '

        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string Location { get; private set; }
        public string PhoneNumber { get; private set; }

        #region ' Acctions '

        public void UpdateProject(string title, string summary, string location, string phoneNumber)
        {
            Title = title;
            Summary = summary;
            Location = location;
            PhoneNumber = phoneNumber;  
        }

        #endregion ' Acctions '

    }
}
