namespace CoAntiCor.Core.Model
{
    /// This class is used to keep track of the last complaint number issued for each year.
    /// This ensures atomic, collision‑free numbering even under heavy load.

    public class ComplaintNumberSequence
    {
        public int Id { get; set; } // always 1 row
        public int Year { get; set; }
        public long LastNumber { get; set; }
    }
}
