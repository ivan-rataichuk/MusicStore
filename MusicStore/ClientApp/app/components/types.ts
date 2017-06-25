export interface RecordResponse {
    records: Record[];
    recordsCount: number;
}

export interface Record {
    title: string;
    author: string;
    year: number;
    comment: string;
    tracks: Track[];
}

export interface Track {
    title: string;
    trackLength: number;
}