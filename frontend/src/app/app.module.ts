import { NgModule } from '@angular/core'
import { RouterModule } from '@angular/router';
import { rootRouterConfig } from './app.routes';
import { AppComponent } from './app.component';
import { GithubService } from './github/shared/github.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { DocumentUploadPage } from './documentUpload/document-upload';
import { DocumentDetailsPage } from './documentDetails/document-details';
import { DocumentSearchPage } from './documentSearch/document-search';
import { RepoBrowserComponent } from './github/repo-browser/repo-browser.component';
import { RepoListComponent } from './github/repo-list/repo-list.component';
import { RepoDetailComponent } from './github/repo-detail/repo-detail.component';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';

import { DropzoneModule } from 'angular2-dropzone-wrapper';
import { DropzoneConfigInterface } from 'angular2-dropzone-wrapper';

import { AppHttpProxy } from './services/app-http-proxy';

const DROPZONE_CONFIG: DropzoneConfigInterface = {
  // Change this to your upload POST address: 
  server: 'http://localhost:55117/api/documentUpload',
  maxFilesize: 50,
  acceptedFiles: 'image/*'
};

@NgModule({
  declarations: [
    AppComponent,
    RepoBrowserComponent,
    RepoListComponent,
    RepoDetailComponent,
    DocumentUploadPage,
    DocumentDetailsPage,
    DocumentSearchPage
  ],
  imports: [
    DropzoneModule.forRoot(DROPZONE_CONFIG),
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    RouterModule.forRoot(rootRouterConfig, { useHash: true })
  ],
  providers: [
    GithubService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {

}
