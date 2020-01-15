namespace APIProject.Interfaces
{
    public interface IModel
    {
        int Max { get; set; }
        int Min { get; set; }
        int Correct { get; set; }
        int AllowedGuesses { get; set; }
        int UsedGuesses { get; set; }
    }
}
