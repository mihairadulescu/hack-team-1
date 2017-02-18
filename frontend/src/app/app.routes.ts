import { Routes } from '@angular/router';


import { RepoBrowserComponent } from './github/repo-browser/repo-browser.component';
import { RepoListComponent } from './github/repo-list/repo-list.component';
import { RepoDetailComponent } from './github/repo-detail/repo-detail.component';
import { DocumentUploadPage } from './documentUpload/document-upload';
import { DocumentDetailsPage } from './documentDetails/document-details';
import { DocumentSearchPage } from './documentSearch/document-search';

export const rootRouterConfig: Routes = [
  { path: '', redirectTo: 'search', pathMatch: 'full' },
  { path: 'search', component: DocumentSearchPage },
  { path: 'upload', component: DocumentUploadPage,  },
  { path: 'details', component: DocumentDetailsPage },
  {
    path: 'github', component: RepoBrowserComponent,
    children: [
      { path: '', component: RepoListComponent },
      {
        path: ':org', component: RepoListComponent,
        children: [
          { path: '', component: RepoDetailComponent },
          { path: ':repo', component: RepoDetailComponent }
        ]
      }]
  },
];

