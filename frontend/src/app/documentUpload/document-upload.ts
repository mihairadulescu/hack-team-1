import { Component } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';
import { DropzoneModule } from 'angular2-dropzone-wrapper';
import { DropzoneConfigInterface } from 'angular2-dropzone-wrapper';


@Component({
  selector: 'documentUpload',
  templateUrl: './document-upload.html',
  styleUrls: ['./document-upload.css']
})

export class DocumentUploadPage {

  constructor(private router: Router) {

  }

  onUploadError($event) {
    
  }

  onUploadSuccess($event){
    console.log($event);
  }

    navigateToDocumentDetailsPage(item) {
    this.router.navigate(['/details'], { queryParams: { fileName: item.OriginalFileName } });
  }
}
