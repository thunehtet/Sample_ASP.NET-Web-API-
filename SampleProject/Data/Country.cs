namespace SampleProject.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShrotName { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }
    }
}
