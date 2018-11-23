using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace StudyBugApp
{
    class CardListTableViewSource : UITableViewSource
    {
        List<string> cards;

        NSString cellIdentifier = new NSString("CardCell");
        UITableViewController callingController;

        public delegate void NewPageHandler(object sender, EventArgs e);
        public event NewPageHandler NewPageEvent;


        public CardListTableViewSource (List<string> cards, UITableViewController callingController)
        {
            this.cards = cards;
            this.callingController=callingController;
        }


        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as UITableViewCell;


            // if no cell exist create one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            }

            var card = cards[indexPath.Row];
            cell.TextLabel.Text = card;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return cards.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
           // base.RowSelected(tableView, indexPath);
            var selectedCard = cards[indexPath.Row];

            //var SelectedItemName = this.cards[indexPath.Row];
           // NewPageEvent(this, new EventArgs());
            // callingController.Car
           SelectedRowId(indexPath.Row);
        }
        public int SelectedRowId(int id)
        {

            return id;
        }


    }
}