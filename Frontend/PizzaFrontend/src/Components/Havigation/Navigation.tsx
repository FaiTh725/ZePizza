import styles from "./Navigation.module.css"

export type Pair = {
    key: string,
    value: string
}

interface NavigationProps {
    links: Pair[]
}

const Navigatin = ({ links = [] }: NavigationProps) => {
    return (
        <nav className={styles.navigationitems}>
            {
                links.map(link =>
                    <a className={styles.link} href={link.key}>{link.value}</a>
                )
            }
        </nav>
    )
}

export default Navigatin;