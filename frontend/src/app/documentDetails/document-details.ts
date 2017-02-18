import { Component } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import { AppHttpProxy } from '../services/app-http-proxy'

@Component({
  selector: 'documentDetails',
  templateUrl: './document-details.html',
  styleUrls: ['./document-details.css', '../app.component.css'],
  providers: [AppHttpProxy]
})

export class DocumentDetailsPage {

  documentFileName;
  selectedTab = "documentText";
  currentDocument: any;

  constructor(private route: ActivatedRoute, private appHttpProxy: AppHttpProxy) {
    this.route
      .queryParams
      .subscribe(params => {
        this.documentFileName = params['fileName'];

        if (this.documentFileName) {
          this.appHttpProxy.getDocumentDetails(this.documentFileName).subscribe(result => {
            this.currentDocument = result;
          });
        }
      });


  }


  saveDocumentChanges() {
    this.appHttpProxy.updateDocument(this.currentDocument).subscribe();
  }

  selectDocumentImageTab() {
    this.selectedTab = "documentImage";
    console.log(this.selectedTab);
  }

  selectDocumentTextTab() {
    this.selectedTab = "documentText";
    console.log(this.selectedTab);
  }
}
