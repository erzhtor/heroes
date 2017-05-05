import $ from 'jquery'

function fetchData<T>(url: string, method: string = 'GET'): Promise<T> {
    return new Promise<T>((resolve: any, reject: any) => {
        $.ajax({
            method: method,
            url: url,
            success: (response) => {
                resolve(response)
            },
            error: (err) => {
                reject(err)
            }
        })
    });
}

export { fetchData }