namespace APIProject.Extra
{
    public class ModelWithoutRules : Interfaces.IModel
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public int Correct { get; set; }
        public int AllowedGuesses { get; set; }
        public int UsedGuesses { get; set; }
    }
}
