import $ from "jquery";

function httpRequest<T>(url: string, method: string = "GET", data: any = null): Promise<T> {
    return new Promise<T>((resolve: any, reject: any) => {
        $.ajax({
            method: method,
            url: url,
            contentType: "application/json",
            data: JSON.stringify(data),
            success: (response) => {
                resolve(response);
            },
            error: (jqXHR: any, textStatus: string, error: string) => {
                reject(`${textStatus} - ${error}`);
            }
        });
    });
}

export { httpRequest };
