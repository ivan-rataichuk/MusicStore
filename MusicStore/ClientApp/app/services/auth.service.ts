import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
    public token: string;

    constructor(private http: Http) {
 
    }

    login(username: string, password: string): Observable<boolean> {
        let headers = new Headers({'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post('/token', JSON.stringify({ username: username, password: password }), options)
            .map((response: Response) => {
                let token = response.json() && response.json().access_token;
                if (token) {
                    this.token = token;
                    return true;
                } else {
                    return false;
                }
            });
    }

    logout(): void {
        this.token = null;
    }
}