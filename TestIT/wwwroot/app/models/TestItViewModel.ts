import { Component } from '@angular/core';

export class TestItViewModel {
    PathToFile: string;
    Argument: string;

    constructor(argument: string,
        pathToFile: string) {
        this.PathToFile = pathToFile;
        this.Argument = argument;
    }
}
