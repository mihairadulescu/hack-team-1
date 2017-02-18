import { Injectable, EventEmitter } from '@angular/core';
import { Http, Headers } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class AppHttpProxy {

    baseUrl: string = 'http://localhost:55117/';
    DOCUMENT_UPDATE: string = 'api/documentUpdate';
    DOCUMENT_SEARCH: string = 'api/documentSearch/{searchPhrase}';
    DOCUMENT_DETAILS: string = 'api/documentDetails/{fileName}';

    contentHeader: Headers = new Headers({
        'Content-Type': 'application/json', 'Accept': 'application/json', 'Cache-Control': 'no-cache',
    });

    constructor(private http: Http) {
        this.DOCUMENT_UPDATE = this.baseUrl + this.DOCUMENT_UPDATE;
        this.DOCUMENT_SEARCH = this.baseUrl + this.DOCUMENT_SEARCH;
        this.DOCUMENT_DETAILS = this.baseUrl + this.DOCUMENT_DETAILS;
    }

    updateDocument(document) {
        return this.http.post(this.DOCUMENT_UPDATE, JSON.stringify(document), { headers: this.contentHeader }).map(res => res.json());
    }



    searchDocument(searchPhrase) {
        var completeUrl = this.DOCUMENT_SEARCH;
        completeUrl = completeUrl.replace("{searchPhrase}", searchPhrase);
        return this.http.get(completeUrl, { headers: this.contentHeader }).map(res => res.json());
    }


    getDocumentDetails(fileName) {
        var completeUrl = this.DOCUMENT_DETAILS;
        completeUrl = completeUrl.replace("{fileName}", fileName);
        return this.http.get(completeUrl, { headers: this.contentHeader }).map(res => res.json());
    }

}
