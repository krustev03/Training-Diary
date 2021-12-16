namespace TrainingDiary.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TrainingDiary.Data.Common.Models;

    public class Training : BaseDeletableModel<int>
    {
        public Training()
        {
            this.Exercises = new HashSet<Exercise>();
        }

        public DateTime Date { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
