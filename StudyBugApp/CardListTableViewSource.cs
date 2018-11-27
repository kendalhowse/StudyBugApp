using System;
using System.Collections.Generic;


using Foundation;
using UIKit;

namespace StudyBugApp
{
    
    class CardListTableViewSource : UITableViewSource
    {
        /// <summary>
        /// Author Ahmed Mohammed
        /// Table view source is the datasource for the cells in table view (list)
        /// 
        /// </summary>
        List<string> cards;
        //Id for cell in the listView
        NSString cellIdentifier = new NSString("CardCell");
        UITableViewController callingController;
        //create a delegate screen page handler
        public delegate void NewPageHandler(object sender, EventArgs e);
        //create page event handler to be perforemed on click on page
        public event NewPageHandler NewPageEvent;

        /// <summary>
        /// Author: Ahmed Mohammed
        /// overloaded constructor to pass list from table View controller to here and process data from source
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="callingController"></param>
        public CardListTableViewSource (List<string> cards, UITableViewController callingController)
        {
            //set passed list from database to be passed to table view controller
            this.cards = cards;
            // set the controller which will show the list 
            this.callingController=callingController;
        }

        /// <summary>
        /// Author: Ahmed Mohammed
        /// return a table view cell (remember cell is in table view controller) with index
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        /// <returns></returns>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // cell passed from table view will be set to the cell here
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as UITableViewCell;


            // if no cell exist create one
            if (cell == null)
            {   //create new cell with defult style and cell to be in the table view controller
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            }
            //each cell will be our item in the card list acordingly with the index in that list
            var card = cards[indexPath.Row];
            // set text of that cell in the list view to card retrieved in the previous step
            cell.TextLabel.Text = card;
            
            return cell;
        }

        /// <summary>
        /// Author: Ahmed Mohammed
        /// return number of rows to be shown in the list (table veiw controller
        /// </summary>
        /// <param name="tableview"></param>
        /// <param name="section"></param>
        /// <returns> interger </returns>
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return cards.Count;
        }


        /// <summary>
        /// Author: Ahmed Mohammed
        /// used to set card that's been tapped on in the list of all cards (table view controller
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
           // base.RowSelected(tableView, indexPath);
            var selectedCard = cards[indexPath.Row];
            //set row id number to be send to details page           
           SelectedRowId(indexPath.Row);
        }

        /// <summary>
        /// Author: Ahmed Mohammed
        /// set selected row id number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelectedRowId(int id)
        {

            return id;
        }


    }
}