namespace clinic.Views.Forms
{
    public interface IDisplayMedicineView
    {
        object DgvDisplayDataSource { get; set; }

        string TxtSearchText { get; set; }
    }

}