using System.Windows.Forms;

namespace RecorteDeCoração.Forms.Interfaces
{
    interface IPaternForm
    {
        // Form currentForm;
        // bool formOpened;

        void SetCurrentForm(Form activity);
        void ClearPanel();
    }
}
