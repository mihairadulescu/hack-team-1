import { Component } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { AppHttpProxy } from '../services/app-http-proxy'

@Component({
  selector: 'documentSearch',
  templateUrl: './document-search.html',
  styleUrls: ['./document-search.css'],
  providers: [AppHttpProxy]
})

export class DocumentSearchPage {

  foundDocuments;
  searchPhrase: string = "";
  constructor(private router: Router, private appHttpProxy: AppHttpProxy) {

    this.appHttpProxy.searchDocument("doc").subscribe(result => {
      this.foundDocuments = result;
    });
  }

  onSearch($event) {
    this.appHttpProxy.searchDocument($event).subscribe(result => {
      console.log("doSearchDocument result");
    });
  }

  navigateToDocumentUploadPage() {
    this.router.navigate(['/upload']);
  }

  navigateToDocumentDetailsPage(item) {
    this.router.navigate(['/details'], { queryParams: { fileName: item.Title } });
  }
}
