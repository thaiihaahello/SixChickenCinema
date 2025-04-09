namespace SixChickenFilm.Models
{
    public class SuatChieu
    {
        public int Id { get; set; }
        public int PhimId { get; set; } // liên kết với phim

        public DateTime GioChieu { get; set; }
        public string Rap { get; set; }
        public string DiaDiem { get; set; }
        public string DinhDang { get; set; }
    }
}
