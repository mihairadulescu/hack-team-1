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
  documentTitle;
  documentText;
  documentCategory;
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
            this.documentTitle = result.Title;
            this.documentText = result.Text;
            this.documentCategory = result.Category;
          });
        }
      });
  }


  saveDocumentChanges() {
    this.currentDocument.Title = this.documentTitle;
    this.currentDocument.Text = this.documentText;
    this.currentDocument.Category = this.documentCategory;
    this.appHttpProxy.updateDocument(this.currentDocument).subscribe();
  }

  selectDocumentImageTab() {
    this.selectedTab = "documentImage";
  }

  selectDocumentTextTab() {
    this.selectedTab = "documentText";
  }
}
