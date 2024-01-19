namespace CrudOperation.Shared
{
    public partial class NavMenu
    {

        private bool showList = false;
        private string listDisplay => showList ? "block" : "none";

        private void ToggleDropdown()
        {
            showList = !showList;
        }

    }
}
