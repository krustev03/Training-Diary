namespace TrainingDiary.Data.Models
{
    using TrainingDiary.Data.Common.Models;

    public class Exercise : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public int TrainingId { get; set; }

        public virtual Training Training { get; set; }
    }
}
