export class CheckEmptyUtil {

    public static isEmpty(value: any): boolean {
        return value === undefined || value === null || value === '';
    }

    public static isNotEmpty(value: any): boolean {
        return !CheckEmptyUtil.isEmpty(value);
    }

    public static isEmptyObject(obj) {
        if (CheckEmptyUtil.isEmpty(obj)) {
            return true;
        }
        for (const key in obj) {
            if (obj.hasOwnProperty(key)) {
                return false;
            }
        }
        return true;
    }

    public static isNotEmptyObject(obj) {
        return !CheckEmptyUtil.isEmptyObject(obj);
    }

}
