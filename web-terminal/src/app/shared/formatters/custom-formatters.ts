export class CustomFormatters {
    static removeLineBreakeCharaters(text: string) : string[] {
        let lines = text.replace('"', '').split('\\r\\n');
        return lines;
    }
}