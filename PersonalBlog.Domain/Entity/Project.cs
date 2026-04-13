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

        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string Owner { get; private set; }
        public string Link { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

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
