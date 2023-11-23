using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iOSPopupErrorRepro
{
    public class PopUpUtil
    {
        public static async Task<object> ShowCheckOutSuccess(Page parent)
        {
            
            var dialog = new AnimDialog
            {
                IconAnimation = "checkmark.json",
                Title = "CheckoutSuccess",
                OkButton = "Back",
                AudioFile = MediaSource.FromResource("CheckOut.mp3"),
                CanBeDismissedByTappingOutsideOfPopup = false
            };
            var result = await parent.ShowPopupAsync(dialog);
            return result;
        }
    }
}
