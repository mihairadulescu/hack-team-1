import { Component } from '@angular/core';
import { DropzoneModule } from 'angular2-dropzone-wrapper';
import { DropzoneConfigInterface } from 'angular2-dropzone-wrapper';


@Component({
  selector: 'documentUpload',
  templateUrl: './document-upload.html',
  styleUrls: ['./document-upload.css']
})

export class DocumentUploadPage {

  constructor() {

  }

  onUploadError($event) {
    
  }

  onUploadSuccess($event){
    console.log("uplaod success");
     console.log($event);
  }
}
