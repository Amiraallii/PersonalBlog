using Personal.Domain.Entity;

namespace PersonalBlog.Domain.Entity
{
    public class Project : Common<int>
    {

        #region ` Consructor '

        private Project()
        {
        }
        public Project(string title, string summary, string owner, string link, DateTime startDate, DateTime? endDate)
        {
            Title = title;
            Summary = summary;
            Owner = owner;
            Link = link;
            StartDate = startDate;
            EndDate = endDate;
        }

        #endregion ` Consructor '

        public string Title { get; set; }
        public string Summary { get; set; }
        public string Owner { get; set; }
        public string Link { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        #region ' Acctions '

        public void UpdateProject(string title, string summary, string owner, string link, DateTime startDate, DateTime? endDate)
        {
            Title = title;
            Summary = summary;
            Owner = owner;
            Link = link;
            StartDate = startDate;  
            EndDate = endDate;
        }

        #endregion ' Acctions '
    }
}
