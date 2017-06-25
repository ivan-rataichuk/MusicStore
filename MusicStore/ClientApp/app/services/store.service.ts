import { Injectable, Inject } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import { Router } from '@angular/router';

import 'rxjs/add/operator/toPromise';

import { Record, RecordResponse } from '../components/types';
import { AuthenticationService } from './auth.service';

@Injectable()
export class StoreService {
    private originUrl: string;

    constructor(private http: Http, private authenticationService: AuthenticationService,
                private router: Router, @Inject('ORIGIN_URL') originUrl: string) {
        this.originUrl = originUrl;
    }

    public getRecords(sorting: number, skip: number, take: number) {
        let headers = new Headers({ 'Authorization': 'Bearer ' + this.authenticationService.token });
        let options = new RequestOptions({ headers: headers });

        return this.http
            .get(this.originUrl + '/api/store/records/' + sorting + "/" + skip + "/" + take, options)
            .toPromise()
            .catch(error => {
                console.error('An error occurred', error);
                this.router.navigate(['/login']);
                return Promise.reject(error.message || error);
            });
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        this.router.navigate(['/login']);
        return Promise.reject(error.message || error);
    }
}