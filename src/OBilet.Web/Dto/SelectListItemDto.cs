namespace OBilet.Web.Dto
{
    public class Select2Dto
    {
        public List<SelectItemDto> Results { get; set; }
    }

    public class SelectItemDto 
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
