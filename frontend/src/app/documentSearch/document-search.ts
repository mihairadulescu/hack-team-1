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
    this.doSearch("");
  }



  doSearch(searchText) {
    this.appHttpProxy.searchDocument(searchText).subscribe(result => {
      result.forEach(item => {
        item.CreatedDate = this.formatDate(item.CreatedDate);
        item = this.updateHighlight(item, searchText);
      });
      this.foundDocuments = result;
    });
  }

  updateHighlight(item, searchText) {

    item.HighlightedTitle = item.Title.replace(new RegExp('(' + searchText + ')', 'ig'),
      '<span class=highlightedContent2>$1</span>');

    item.HighlightedText = item.Text.replace(new RegExp('(' + searchText + ')', 'ig'),
      '<span class=highlightedContent2>$1</span>');

    return item;
  }


  onSearch($event) {
    this.doSearch($event);
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
