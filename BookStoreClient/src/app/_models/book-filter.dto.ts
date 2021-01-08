import { Injectable } from "@angular/core";

export abstract class BaseFilterDto {
    getQueryString(): string {
        let params = '';
        Object.keys(this)
            .forEach((key: string, i: number) => {
                if (this[key]) {
                    params += i === 0 ? '?' : '&';
                    params += `${key}=${this[key]}`;
                }
            });

        return params;
    }
}

@Injectable({
    providedIn: 'root'
})
export class BookFilterDto extends BaseFilterDto {
    searchByTitle: string;
    sortOrder: string = "Title";
    minPrice: number;
    maxPrice: number;
    pageNumber: number;
    pageSize: number;
}