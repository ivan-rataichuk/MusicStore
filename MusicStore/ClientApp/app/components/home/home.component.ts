import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../../services/auth.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
})

export class HomeComponent implements OnInit {
    model: any = {};
    loading = false;
    error = '';

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService) { }

    ngOnInit() {
        this.authenticationService.logout();
    }

    login() {
        this.loading = true;
        this.authenticationService.login(this.model.username, this.model.password)
            .subscribe(result => {
                if (result === true) {
                    this.router.navigate(['/fetch-data']);
                } else {
                    this.error = 'Username or password is incorrect';
                    this.loading = false;
                }
            }, error => {
                this.error = 'Username or password is incorrect';
                this.loading = false;
            });
    }
}