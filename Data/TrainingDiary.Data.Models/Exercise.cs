namespace TrainingDiary.Data.Models
{
    using TrainingDiary.Data.Common.Models;

    public class Exercise : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public int TrainingId { get; set; }

        public virtual Training Training { get; set; }
    }
}
