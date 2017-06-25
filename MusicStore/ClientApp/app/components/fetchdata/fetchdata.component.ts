import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Record, RecordResponse } from '../types';
import { StoreService } from '../../services/store.service';
import { AuthenticationService } from '../../services/auth.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html',
    providers: [StoreService]
})
export class FetchDataComponent {
    public records: Record[];
    public canGetNext: boolean = false;
    public canGetPrevious: boolean = false;
    public page: number = 1;
    public pageCount: number;
    public sorting: number = 0; 

    private skip: number = 0;
    private take: number = 2;
    private recordsCount: number;
    private originUrl: string;
    private http: Http;
    

    constructor(private storeService: StoreService) {
        this.getRecords();
    }

    getRecords() {
        this.storeService.getRecords(this.sorting, this.skip, this.take)
            .then(response => {
                let result = response.json() as RecordResponse;
                this.records = result.records;
                this.recordsCount = result.recordsCount;

                this.checkRecordsCount();
                this.pageCount = Math.ceil(this.recordsCount / this.take);
            });
    }

    checkRecordsCount() {
        if (this.recordsCount >= (this.skip + this.take))
            this.canGetNext = true;
        else
            this.canGetNext = false;

        if (this.skip <= 0)
            this.canGetPrevious = false;
        else 
            this.canGetPrevious = true;
    }

    getNext() {
        if (!this.canGetNext)
            return;

        this.skip += this.take;
        this.getRecords();
        this.page++;
    }

    getPrevious() {
        if (!this.canGetPrevious)
            return;

        this.skip -= this.take;
        if (this.skip < 0)
            this.skip = 0;

        this.getRecords();
        this.page--;
    }

    sortByTitle() {
        this.sorting = 0;
        this.getRecords();
    }

    sortByAuthor() {
        this.sorting = 1;
        this.getRecords();
    }

    sortByYear() {
        this.sorting = 2;
        this.getRecords();
    }
}