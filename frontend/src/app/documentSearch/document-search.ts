import { Component } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { AppHttpProxy } from '../services/app-http-proxy'
import { MomentModule } from 'angular2-moment'

@Component({
  selector: 'documentSearch',
  templateUrl: './document-search.html',
  styleUrls: ['./document-search.css'],
  providers: [AppHttpProxy],
})

export class DocumentSearchPage {

  foundDocuments: Array<any>;

  constructor(private router: Router, private appHttpProxy: AppHttpProxy, private moment: MomentModule) {

    this.appHttpProxy.searchDocument("doc").subscribe(result => {
      this.foundDocuments = result;
      this.foundDocuments.forEach(item => { item.CreatedDate = this.formatDate(item.CreatedDate); });
    });
  }

  onSearch($event) {
    this.appHttpProxy.searchDocument($event).subscribe(result => {
      this.foundDocuments = result;
      this.foundDocuments.forEach(item => { item.CreatedDate = this.formatDate(item.CreatedDate); });
      console.log(result);
    });
  }

  navigateToDocumentUploadPage() {
    this.router.navigate(['/upload']);
  }

  navigateToDocumentDetailsPage(item) {
    this.router.navigate(['/details'], { queryParams: { fileName: item.Title } });
  }


  formatDate(inputDate){
    return inputDate;
  }
}
