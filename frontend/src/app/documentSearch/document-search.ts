import { Component, ViewEncapsulation } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { AppHttpProxy } from '../services/app-http-proxy'
import { MomentModule } from 'angular2-moment'

@Component({
  selector: 'documentSearch',
  templateUrl: './document-search.html',
  styleUrls: ['./document-search.css'],
  providers: [AppHttpProxy],
  encapsulation: ViewEncapsulation.None,
})

export class DocumentSearchPage {

  foundDocuments: Array<any>;

  constructor(private router: Router, private appHttpProxy: AppHttpProxy, private moment: MomentModule) {

    this.appHttpProxy.searchDocument("doc").subscribe(result => {
       result.forEach(item => {
        item.CreatedDate = this.formatDate(item.CreatedDate);
        item = this.updateHighlight(item, "");
      });
      this.foundDocuments = result;
    });
  }





  updateHighlight(item, searchText) {
    item.HighlightedText = item.Text.replace(new RegExp('(' + searchText + ')', 'ig'),
      '<span class=highlightedContent2>$1</span>');
    return item;
  }


  onSearch($event) {

    this.appHttpProxy.searchDocument($event).subscribe(result => {
      result.forEach(item => {
        item.CreatedDate = this.formatDate(item.CreatedDate);
        item = this.updateHighlight(item, $event);
      });
      this.foundDocuments = result;
    });
  }

  navigateToDocumentUploadPage() {
    this.router.navigate(['/upload']);
  }

  navigateToDocumentDetailsPage(item) {
    this.router.navigate(['/details'], { queryParams: { fileName: item.OriginalFileName } });
  }


  formatDate(inputDate) {
    return inputDate;
  }
}
